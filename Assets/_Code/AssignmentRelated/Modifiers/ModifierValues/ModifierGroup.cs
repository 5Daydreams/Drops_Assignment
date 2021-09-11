using System;
using System.Collections.Generic;
using _Code.AssignmentRelated.DropSystem._3_ItemBase.BaseTypeData;
using _Code.AssignmentRelated.StatSystem;
using UnityEngine;
using Random = UnityEngine.Random;

namespace _Code.AssignmentRelated.Modifiers.ModifierValues
{
    [CreateAssetMenu(menuName = "ItemDropPool/ModifierHolder")]
    public class ModifierGroup : ScriptableObject
    {
        public ModifierValueRange[] ModifierValues;
        
        public List<FullStatValue> RollModifierValues()
        {
            List<FullStatValue> modValues = new List<FullStatValue>();
            
            for (int i = 0; i < ModifierValues.Length; i++)
            {
                modValues.Add(new FullStatValue());
                modValues[i].TryAddModifier(ModifierValues[i].ModValue);
            }
    
            return modValues;
        }

        public ModifierGroupInstance GetAsInstance()
        {
            ModifierGroupInstance groupInstance = new ModifierGroupInstance
            {
                ModifierValues = this.ModifierValues
            };
            return groupInstance;
        }
        
    }

    [Serializable]
    public class ModifierGroupInstance
    {
        public ModifierValueRange[] ModifierValues;
    }
    
    [Serializable] 
    public struct ModifierValueRange
    {
        // protected int tier;
        
        public float MinModValue;
        public float MaxModValue;
        public RawModifierValue ModValue;
    
        public float RerollValue()
        {
            return ModValue.RerollBetween(MinModValue, MaxModValue);
        }
    }

    [Serializable] 
    public class RawModifierValue : StatValue
    {
        public float RerollBetween(float minVal, float maxVal)
        {
            ModValue = Random.Range(minVal, maxVal);
            return ModValue;
        }
    }
        
    [Serializable] 
    public class StatValue
    {
        public float ModValue;
        public StatTag ModTargetStatTag;
        public ModifierOperationTag ModOpTag;

        public RawModifierValue ToRawMod()
        {
            RawModifierValue localModConverted = new RawModifierValue();
            localModConverted.ModValue = ModValue;
            localModConverted.ModOpTag = ModOpTag;
            localModConverted.ModTargetStatTag = ModTargetStatTag;

            return localModConverted;
        }
    }

}