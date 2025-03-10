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

    private Coroutine damageCoroutine;
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
        hunger.Add(amount);
    }
    public void DecreaseStamina(float amount)
    {
        stamina.SubStract(amount);
        if (stamina.curValue <= 0f)
        {
            stamina.curValue = 0;
        }
    }
    public void TakeDamage(ItemData item)
    {
        foreach (var consumable in item.consumables)
        {
            if (item.type == ItemType.Poisonous)
            {
                if (damageCoroutine != null)
                {
                    StopCoroutine(damageCoroutine);
                }
                damageCoroutine = StartCoroutine(OnTakeDamageTime(consumable.value, 5f));
            }
        }
    }
    private IEnumerator OnTakeDamageTime(float damagePerSecond, float duration)
    {
        float applyTime = 0f; //효과경과시간

        while(applyTime < duration) //지속시간이 경과시간보다 클 때, 효과가 적용되어야할 때
        {
            health.SubStract(damagePerSecond * Time.deltaTime);
            health.curValue = MathF.Max(health.curValue, 0); // mathF를 통해서 0과 현재체력 중 최대값으로 curValue설정
            Debug.Log(health.curValue);

            applyTime += Time.deltaTime; //경과시간 증가
            yield return null; //효과지속시간이 끝날 때 null을 통해 감소저주 정지
        }
        damageCoroutine = null; //코루틴 종료 후 초기화
    }

    public void Die()
    {
        Debug.Log("죽었음.");
    }
}
