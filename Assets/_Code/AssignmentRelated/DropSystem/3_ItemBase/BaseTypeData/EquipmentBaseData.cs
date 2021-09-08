using System;
using System.Collections.Generic;
using _Code;
using _Code.StatSystem;
using UnityEngine;

[CreateAssetMenu(menuName = "ItemDropPool/EquipmentBase")]
public class EquipmentBaseData : InventoryItemBaseData
{
    // ?
    public List<StatValue> EquipmentBaseStats;
    public EquipmentTag EquipmentSlot;
    
    public override void UseItem()
    {
        base.UseItem();
        EquipmentManager.instance.Equip(this);
        // RemoveFromInventory();
    }
}

[Serializable]
public struct StatValue
{
    public StatTag AssociatedStatTag;
    public float AssociatedStatValue;

    public StatValue(StatTag tag, float statValue)
    {
        AssociatedStatTag = tag;
        AssociatedStatValue = statValue;
    }
}