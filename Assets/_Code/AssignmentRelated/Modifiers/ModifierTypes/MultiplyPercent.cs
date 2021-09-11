using System;
using UnityEngine;

namespace _Code.ModifierOperations
{
    [CreateAssetMenu(menuName = "ItemDropPool/ModifiersTypes/MultiplyPercent")]
    public class MultiplyPercent : ModifierOperationType
    {
        public override Func<float,float,float> GetOperation()
        {
            float Multiply(float a, float b)
            {
                return a * b;
            }
        
            return Multiply;
        }
    }
}