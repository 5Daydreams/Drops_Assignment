using System;
using System.Collections.Generic;
using _Code.ModifierOperations;
using _Code.StatSystem;
using UnityEngine;
using Random = UnityEngine.Random;

namespace _Code
{
    [CreateAssetMenu(menuName = "ItemDropPool/ModifierHolder")]
    public class ModifierHolder : ScriptableObject
    {
        public ModifierRange[] ModifierValues;
        
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
    
    [Serializable] public struct ModifierRange
    {
        // protected int tier;
        
        public float MinModValue;
        public float MaxModValue;
        public StatTag ModTargetStat;
        public ModifierOperationType ModTargetStatValue;
    
        public StatValue ToStatValue()
        {
            var tag = ModTargetStat;
            float randomizedValue = GetRandomValue();
            return new StatValue(tag, randomizedValue);
        }

        private float GetRandomValue()
        {
            return Random.Range(MinModValue, MaxModValue);
        }
    }
}