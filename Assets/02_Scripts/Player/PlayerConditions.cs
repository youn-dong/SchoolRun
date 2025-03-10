using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerConditions : MonoBehaviour
{
    public UICondition uicondition;
    public Conditions health { get { return uicondition.health; } }
    public Conditions hunger { get { return uicondition.hunger; } }
    public Conditions stamina { get { return uicondition.stamina; } }

    [Header("체력감소속도")]
    public float noHungerHealthDecay;
    // Start is called before the first frame update
    void Update()
    {
        hunger.SubStract(hunger.passiveValue * Time.deltaTime);
        stamina.Add(stamina.passiveValue * Time.deltaTime);

        if(hunger.curValue <=0f)
        {
            health.SubStract(noHungerHealthDecay * Time.deltaTime);
        }
        if(health.curValue <= 0f)
        {
            Die();
        }
    }
    public void Heal(float amount)
    {
        health.Add(amount);
    }
    public void Eat(float amount)
    {
    }
    public void DecreaseStamina(float amount)
    {
        stamina.SubStract(amount);
        if (stamina.curValue <= 0f)
            stamina.curValue = 0;
    }
    public void Die()
    {
        Debug.Log("죽었음.");
    }
}
