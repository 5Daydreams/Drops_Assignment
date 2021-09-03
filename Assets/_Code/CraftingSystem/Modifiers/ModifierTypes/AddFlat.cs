using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace _Code.ModifierOperations
{
    [CreateAssetMenu(menuName = "ItemDropPool/ModifiersTypes/Add")]
    public class AddFlat : ModifierValueInfo
    {
        public float MinFlat;
        public float MaxFlat;
        
        public override Func<float,float,float> GetOperation()
        {
            float Increase(float a, float b)
            {
                return a + b;
            }
        
            return Increase;
        }
        
        public override float GetMinValue()
        {
            return MinFlat;
        }

        public override float GetMaxValue()
        {
            return MaxFlat;
        }

        public override float GetRandomValueByTier(int tier)
        {
            return (int) Random.Range(MinFlat, MaxFlat + 1);
        }
    }
}