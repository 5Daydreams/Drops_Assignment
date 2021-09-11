using System;
using System.Collections.Generic;
using System.Linq;
using _Code.AssignmentRelated.Modifiers.ModifierValues;
using _Code.AssignmentRelated.StatSystem;
using BrackeysImport._Code.Inventory;
using FG_Toolbox.MathExtensions;
using UnityEngine;

namespace _Code.AssignmentRelated.DropSystem._3_ItemBase.BaseTypeData
{
    public class EquipmentStats : InventoryItemBase
    {
        public EquipmentBaseData BaseStats;
        
        [SerializeField] private List<FullStatValue> FinalStats;
        
        [Space]
        [SerializeField] private List<ModifierGroupInstance> ImplicitModPool;
        private List<ModifierValueRange> implicitValueRanges;
        
        [Space]
        [SerializeField] private List<ModifierGroupInstance> CachedExplicitValues;
        private List<ModifierValueRange> explicitValueRanges;
        
        
        public override void UseItem()
        {
            AdjustFinalValues();
            EquipmentManager.instance.Equip(this);
        }

        public void RerollItemRarity()
        {
            
        }

        public void GetNewImplicitModifiers() // Is this even useful??
        {
            implicitValueRanges.Clear();
            foreach (var mod in ImplicitModPool)
            {
                foreach (var modRange in mod.ModifierValues)
                {
                    implicitValueRanges.Add(modRange);
                }
            }
        }

        public void GetNewExplicitModifiers() // Chaos Orb
        {
            CachedExplicitValues.Clear();

            List<ModifierGroupInstance> allExplicitModGroups = BaseStats.ExplicitModPool.GetGroupInstances();
            int modCount = Mathf.Clamp(Rarity.GetModCountFromRarity(),0,allExplicitModGroups.Count);

            if (modCount > 0)
            {
                CachedExplicitValues = allExplicitModGroups.GetRandomElements(modCount).ToList();
            }
            
            explicitValueRanges.Clear();

            foreach (var modGroup in CachedExplicitValues)
            {
                for (int i = 0; i < modGroup.ModifierValues.Length; i++)
                {
                    explicitValueRanges.Add(modGroup.ModifierValues[i]);
                }
            }
            
            RerollExplicitModifierValues();
        }

        public void RerollImplicitModifierValues() // Blessed Orb
        {
            foreach (var range in implicitValueRanges)
            {
                range.RerollValue();
            }
            
            AdjustFinalValues();
        }
        
        public void RerollExplicitModifierValues() // Divine Orb
        {
            foreach (var range in explicitValueRanges)
            {
                range.RerollValue();
            }
            
            AdjustFinalValues();
        }

        private void AdjustFinalValues()
        {
            List<FullStatValue> finalStatValues = new List<FullStatValue>();
            List<RawModifierValue> rawModValues = new List<RawModifierValue>();

            foreach (var implicitMod in implicitValueRanges)
            {
                rawModValues.Add(implicitMod.ModValue);
            }

            foreach (var explicitMod in explicitValueRanges)
            {
                rawModValues.Add(explicitMod.ModValue);
            }

            foreach (var localMod in BaseStats.EquipmentLocalValues)
            {
                rawModValues.Add(localMod.ToRawMod());
            }

            foreach (var rawMod in rawModValues)
            {
                FullStatValue correspondingStat = finalStatValues.Find(statValue => statValue.AssociatedStatTag == rawMod.ModTargetStatTag);
                if (correspondingStat == null)
                {
                    correspondingStat = new FullStatValue(rawMod.ModTargetStatTag);
                    finalStatValues.Add(correspondingStat);
                }
                
                correspondingStat.TryAddModifier(rawMod);
            }

            FinalStats = finalStatValues;

            foreach (var stat in FinalStats)
            {
                stat.GetFinalValue();
            }
        }
    }

    [Serializable]
    public class FullStatValue
    {
        public StatTag AssociatedStatTag;
        public bool localMod = true;
        public float FinalValue = 0;
        public List<float> FlatTotal = new List<float>();
        public List<float> IncreaseMultipliers = new List<float>();
        public List<float> MoreMultipliers = new List<float>();
    
        public FullStatValue() { }
    
        public FullStatValue(StatTag tag)
        {
            AssociatedStatTag = tag;
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

            if (flatSum < 1)
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

            FinalValue = finalValue;
            return finalValue;
        }

        public void TryAddModifier(StatTag tag, float statValue, ModifierOperationTag modOperation)
        {
            if (tag != AssociatedStatTag)
            {
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
    
        public void TryAddModifier(RawModifierValue mod)
        {
            TryAddModifier(mod.ModTargetStatTag,mod.ModValue,mod.ModOpTag);
        }
    }

    public enum ModifierOperationTag
    {
        Add,
        Increase,
        More
    }
}