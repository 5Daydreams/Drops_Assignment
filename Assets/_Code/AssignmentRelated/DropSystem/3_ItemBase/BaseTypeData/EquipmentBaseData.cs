using System;
using System.Collections.Generic;
using _Code;
using _Code.StatSystem;
using UnityEngine;

[CreateAssetMenu(menuName = "ItemDropPool/EquipmentBase")]
public class EquipmentBaseData : ScriptableObject
{
    public List<StatValue> EquipmentBaseStats;
    public EquipmentTag EquipmentSlot;

    public ModifierPool ExplicitModPool;
}