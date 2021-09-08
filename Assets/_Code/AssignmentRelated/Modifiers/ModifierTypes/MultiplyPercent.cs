using System;
using UnityEngine;

namespace _Code.ModifierOperations
{
    [CreateAssetMenu(menuName = "ItemDropPool/ModifiersTypes/MultiplyPercent")]
    public class MultiplyPercent : ModifierValueInfo
    {
        [Range(0.5f, 2.0f)] public float MinMultiplier;
        [Range(0.5f, 2.0f)] public float MaxMultiplier;

        public override Func<float,float,float> GetOperation()
        {
            float Multiply(float a, float b)
            {
                return a * b;
            }
        
            return Multiply;
        }

        public override float GetMinValue()
        {
            return MinMultiplier;
        }

        public override float GetMaxValue()
        {
            return MaxMultiplier;
        }

        public override float GetRandomValueByTier(int tier)
        {
            throw new NotImplementedException();
        }
    }
}