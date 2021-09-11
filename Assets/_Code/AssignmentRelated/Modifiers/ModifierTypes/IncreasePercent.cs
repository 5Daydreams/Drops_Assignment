using System;
using UnityEngine;

namespace _Code.AssignmentRelated.Modifiers.ModifierTypes
{
    [CreateAssetMenu(menuName = "ItemDropPool/ModifiersTypes/IncreasePercent")]
    public class IncreasePercent : ModifierOperationType
    {
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