using System;
using UnityEngine;

namespace _Code.AssignmentRelated.Modifiers.ModifierTypes
{
    [CreateAssetMenu(menuName = "ItemDropPool/ModifiersTypes/Add")]
    public class AddFlat : ModifierOperationType
    {
        public override Func<float,float,float> GetOperation()
        {
            float Add(float a, float b)
            {
                return a + b;
            }
        
            return Add;
        }
    }
}