using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace _Code.ModifierOperations
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