using System;
using System.Collections.Generic;
using System.Linq;
using _Code.ModifierOperations;
using _Code.StatSystem;
using UnityEngine;
using Random = UnityEngine.Random;

namespace _Code
{
    [CreateAssetMenu(menuName = "ItemDropPool/ModifierHolder")]
    public class ModifierGroup : ScriptableObject
    {
        public ModifierValueRange[] ModifierValues;
        
        public List<EquipmentStatValue> RollModifierValues()
        {
            List<EquipmentStatValue> modValues = new List<EquipmentStatValue>();
            
            for (int i = 0; i < ModifierValues.Length; i++)
            {
                modValues.Add(new EquipmentStatValue());
                modValues[i].AddModifier(ModifierValues[i]);
            }
    
            return modValues;
        }
    }
    
    [Serializable] 
    public struct ModifierValueRange
    {
        // protected int tier;
        
        public float MinModValue;
        public float MaxModValue;
        public RawModifierValue ModValue;
    
        public float GetValue()
        {
            return ModValue.RerollBetween(MinModValue, MaxModValue);
        }
    }
    
    [Serializable] 
    public class StatValue
    {
        public float ModValue;
        public StatTag ModTargetStatTag;
        public ModifierOperationTag ModOpTag;
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
}