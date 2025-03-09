using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerConditions : MonoBehaviour
{
    public UICondition uicondition;
    Conditions health { get { return uicondition.health; } }
    Conditions hunger { get { return uicondition.hunger; } }
    Conditions stamina { get { return uicondition.stamina; } }

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
    public void Die()
    {
        Debug.Log("죽었음.");
    }
}
