using System;
using System.Collections.Generic;
using _Code.ModifierOperations;
using _Code.StatSystem;
using UnityEngine;

namespace _Code
{
    [CreateAssetMenu(menuName = "ItemDropPool/ModifierHolder")]
    public class ModifierHolder : ScriptableObject
    {
        public ModifierValue[] ModifierValues;
        
        public List<StatValue> RollModifierValues()
        {
            List<StatValue> modValues = new List<StatValue>();
            
            for (int i = 0; i < ModifierValues.Length; i++)
            {
                modValues.Add(ModifierValues[i].ToStatValue());
            }

            return modValues;
        }
    }
    
    [Serializable] public struct ModifierValue
    {
        // protected int tier;
        public StatTag ModTargetStat;
        public ModifierValueInfo ModTargetStatValue;

        public StatValue ToStatValue()
        {
            var tag = ModTargetStat;
            float randomizedValue = ModTargetStatValue.GetRandomValueByTier(0);
            return new StatValue(tag, randomizedValue);
        }
    }
}