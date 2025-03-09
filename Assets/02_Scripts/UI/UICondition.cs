using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UICondition : MonoBehaviour
{
    [Header("Player의 Info")]
    public Conditions health;
    public Conditions hunger;
    public Conditions stamina;

    private void Start()
    {
        ChracterManager.Instance.Player.conditions.uicondition = this;
    }
}
