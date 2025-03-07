using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    Usable,
    Display,
    Consumable
}
public enum ConsumableType
{
    Health,
    Hunger
}
[Serializable]
public class ItemDataConsumable
{
    public ConsumableType consumableType;
    public float value;
}
[CreateAssetMenu(fileName = "Item", menuName = "New Item")]
public class ItemData : ScriptableObject
{
    [Header("Info")]
    public string ItemName;
    public string description;
    public ItemType itemType;
    public Mesh icon;
    public GameObject dropPrefab;

    [Header("Stacking")]
    public bool canStack;
    public int maxStackAmount;

    [Header("Consumable")]
    public ItemDataConsumable[] consumables;
}
