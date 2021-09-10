using System;
using UnityEngine;

namespace _Code.ModifierOperations
{
    [CreateAssetMenu(menuName = "ItemDropPool/ModifiersTypes/IncreasePercent")]
    public class IncreasePercent : ModifierOperationType
    {
        [Range(0.5f, 2.0f)] public float MinMultiplier;
        [Range(0.5f, 2.0f)] public float MaxMultiplier;

        public override Func<float,float,float> GetOperation()
        {
            float Increase(float a, float b)
            {
                return a + b;
            }
        
            return Increase;
        }
    }
}