using System;
using System.Collections.Generic;
using _Code;
using _Code.StatSystem;
using UnityEngine;

[CreateAssetMenu(menuName = "ItemDropPool/EquipmentBase")]
public class EquipmentBaseData : ItemBaseData
{
    // ?
    public List<StatValue> EquipmentBaseStats;
}

[Serializable]
public struct StatValue
{
    public string Label;
    public StatTag AssociatedStatTag;
    public float AssociatedStatValue;
}