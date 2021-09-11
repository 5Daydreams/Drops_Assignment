using System;
using System.Collections.Generic;
using System.IO.Compression;
using _Code;
using _Code.Extensions;
using _Code.ModifierOperations;
using _Code.StatSystem;
using Unity.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

namespace _Code.AssignmentRelated.DropSystem._3_ItemBase.BaseTypeData
{
    public class EquipmentStats : InventoryItemBase
    {
        public EquipmentBaseData BaseStats;
        
        [SerializeField] private List<EquipmentStatValue> FinalStats;
        
        [Header("Implicits")]
        [SerializeField] private List<ModifierGroup> ImplicitModPool;
        [SerializeField] private List<EquipmentStatValue> ImplicitValues;
        
        [Header("Explicits")]
        [SerializeField] private ItemRarity Rarity;
        [SerializeField] private List<ModifierGroup> CachedExplicitValues;
        [SerializeField] private List<EquipmentStatValue> ExplicitValues;
        
        
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

            AdjustFinalValues();
        }
        
        public void RollExplicitModifierValues() // Divine Orb
        {
            ExplicitValues.Clear();
            foreach (var mod in CachedExplicitValues)
            {
                foreach (var statValue in mod.RollModifierValues())
                {
                    ExplicitValues.Add(statValue);
                }
            }
            AdjustFinalValues();
        }

        public void PickExplicitsFromPool()
        {
            BaseStats.ExplicitModPool.Holders.GetRandomElements(Rarity.MaxModSlots);
            
            CachedExplicitValues = BaseStats.ExplicitModPool.Holders;
        }

        private List<StatTag> GetLocalTags
        {
            get
            {
                List<StatTag> localTags = new List<StatTag>();

                foreach (var localValue in BaseStats.EquipmentLocalValues)
                {
                    localTags.Add(localValue.ModTargetStatTag);
                }

                return localTags;
            }
        }
        
        private void AdjustFinalValues()
        {
            List<EquipmentStatValue> finalStatValues = new List<EquipmentStatValue>();

            List<StatTag> itemTags = GetLocalTags;

            foreach (var implicitMod in ImplicitValues)
            {
                if (itemTags.Contains(implicitMod.AssociatedStatTag))
                {
                    continue;
                }
                itemTags.Add(implicitMod.AssociatedStatTag);
            }

            foreach (var explicitMod in ExplicitValues)
            {
                if (itemTags.Contains(explicitMod.AssociatedStatTag))
                {
                    continue;
                }
                itemTags.Add(explicitMod.AssociatedStatTag);
            }
            
            // all tags are here 
            // I'd like a method to get all mods based on a tag

            foreach (var statTag in itemTags)
            {
                EquipmentStatValue finalValuePerStatTag = new EquipmentStatValue();
                finalValuePerStatTag.AssociatedStatTag = statTag;

                foreach (var implicitMod in ImplicitValues)
                {
                    if (implicitMod.AssociatedStatTag == finalValuePerStatTag.AssociatedStatTag)
                    {
                        //finalValuePerStatTag.AddModifier();
                    }
                }
                
                // finalStatValues.Add();
            }
        }
    }
}

[Serializable] 
public class ItemRarity
{
    public Color RarityColor = Color.white;
    public int MinModSlots = 0;
    public int MaxModSlots = 2;

    public int GetModCountFromRarity()
    {
        return Random.Range(MinModSlots, MaxModSlots + 1);
    }
}

// [Serializable]
// public struct LocalStatValue
// {
//     public StatTag AssociatedStatTag;
//     public float FlatValue;
// }

[Serializable]
public struct EquipmentStatValue
{
    public StatTag AssociatedStatTag;
    public bool localMod;
    public List<float> FlatTotal;
    public List<float> IncreaseMultipliers;
    public List<float> MoreMultipliers;

    public EquipmentStatValue(StatTag tag, float statValue, ModifierOperationTag modOperation)
    {
        AssociatedStatTag = tag;
        localMod = true;
        FlatTotal = new List<float>();
        IncreaseMultipliers = new List<float>();
        MoreMultipliers = new List<float>();
    }
    
    public float GetFinalValue()
    {
        float finalValue = 0;

        float flatSum = 0;
        foreach (var flat in FlatTotal)
        {
            flatSum += flat;
        }

        finalValue += flatSum;

        if (flatSum == 0)
        {
            localMod = false;
            finalValue = 1;
        }
        
        float increases = 1;
        foreach (var incr in IncreaseMultipliers)
        {
            increases += incr;
        }

        finalValue *= increases;
        
        foreach (var more in MoreMultipliers)
        {
            finalValue *= more;
        }

        return finalValue;
    }

    public void AddModifier(StatTag tag, float statValue, ModifierOperationTag modOperation)
    {
        if (tag != AssociatedStatTag)
        {
            Debug.LogError("Tag is invalid for this mod");
            return;
        }

        switch (modOperation)
        {
            case ModifierOperationTag.Add:
            {
                FlatTotal.Add(statValue);
                return;
            }
            case ModifierOperationTag.Increase:
            {
                IncreaseMultipliers.Add(statValue);
                return;
            }
            case ModifierOperationTag.More:
            {
                MoreMultipliers.Add(statValue);
                return;
            }
        }
    }
    
    public void AddModifier(ModifierValueRange mod)
    {
        AddModifier(mod.ModValue.ModTargetStatTag,mod.GetValue(),mod.ModValue.ModOpTag);
    }
}

public enum ModifierOperationTag
{
    Add,
    Increase,
    More
}