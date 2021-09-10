using System;
using System.Collections.Generic;
using _Code.StatSystem;
using UnityEngine;

namespace _Code.AssignmentRelated.DropSystem._3_ItemBase.BaseTypeData
{
    public class EquipmentStats : InventoryItemBase
    {
        public EquipmentBaseData BaseStats;
        
        [Header("Final Stats")]
        [SerializeField] private List<StatValue> FinalStats;
        
        [Header("Implicits")]
        [SerializeField] private List<ModifierHolder> ImplicitModPool;
        [SerializeField] private List<StatValue> ImplicitValues;
        
        [Header("Explicits")]
        [SerializeField] private ItemRarity Rarity;
        [SerializeField] private List<StatValue> ExplicitValues;
        
        
        public override void UseItem()
        {
            EquipmentManager.instance.Equip(this);
        }
        
        public void RollImplicitModifierValues() // Blessed Orb
        {
            ImplicitValues.Clear();
            foreach (var mod in ImplicitModPool)
            {
                foreach (var statValue in mod.RollModifierValues())
                {
                    ImplicitValues.Add(statValue);
                }
            }
        }
        
        public void RollExplicitModifierValues() // Divine Orb
        {
            ExplicitValues.Clear();
            foreach (var mod in BaseStats.ExplicitModPool.Holders)
            {
                foreach (var statValue in mod.RollModifierValues())
                {
                    ExplicitValues.Add(statValue);
                }
            }
        }

        public void PickExplicitsFromPool()
        {
            
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