using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace _Code
{
    [CreateAssetMenu(menuName = "ItemDropPool/ModifierValue/Implicit")]
    public class ImplicitModifierValue : ItemModifierValue
    {
        public override float ApplyModifier(float targetValue)
        {
            Func<float,float,float> operation = modValueInfoOperation.GetOperation();

            var randomizedModValue = Random.Range(modValueInfoOperation.GetMinValue(), modValueInfoOperation.GetMaxValue());   
            
            return operation(targetValue,randomizedModValue);            
        }
    }
}