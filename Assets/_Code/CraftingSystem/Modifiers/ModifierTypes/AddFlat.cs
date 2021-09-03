using System;
using UnityEngine;

namespace _Code.ModifierOperations
{
    [CreateAssetMenu(menuName = "ItemDropPool/ModifiersTypes/Add")]
    public class AddFlat : ModifierValueInfo
    {
        public int MinFlat;
        public int MaxFlat;
        
        public override Func<float, float, float> GetOperation()
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
    }
}