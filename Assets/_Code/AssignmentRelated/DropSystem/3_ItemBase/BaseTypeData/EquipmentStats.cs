using System;
using System.Collections.Generic;
using _Code.StatSystem;
using UnityEngine;

namespace _Code.AssignmentRelated.DropSystem._3_ItemBase.BaseTypeData
{
    public class EquipmentStats : InventoryItemBase
    {
        public EquipmentBaseData BaseStats;
        
        [Header("Implicits")]
        [SerializeField] private List<StatValue> ImplicitValues;
        public List<ModifierHolder> ImplicitModPool;
        
        [Header("Explicits")]
        [SerializeField] private ItemRarity Rarity;
        [SerializeField] private List<ModifierHolder> ExplicitModPool;
        private List<StatValue> RolledModValues = new List<StatValue>();
        
        [Header("Final Stats")]
        [SerializeField] private List<StatValue> FinalStats;
        
        public override void UseItem()
        {
            EquipmentManager.instance.Equip(this);
        }
        
        public void RollImplicitModifierValues()
        {
            foreach (var mod in ImplicitModPool)
            {
                ImplicitValues = mod.RollModifierValues();
            }
        }
    }
}

[Serializable] public class ItemRarity
{
    public Color RarityColor = Color.white;
    public int MaxModSlots = 0;
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