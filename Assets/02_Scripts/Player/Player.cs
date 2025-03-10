using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public PlayerConditions conditions;
    public PlayerController controller;

    public ItemData itemData;
    public Action addItem;

    public Transform dropPosition;
    private void Awake()
    {
        ChracterManager.Instance.Player = this;
        controller = GetComponent<PlayerController>();
        conditions = GetComponent<PlayerConditions>();
    }
}
