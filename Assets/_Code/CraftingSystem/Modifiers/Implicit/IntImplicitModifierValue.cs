using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace _Code
{
    [CreateAssetMenu(menuName = "ItemDropPool/ModifierValue/Integer Implicit")]
    public class IntImplicitModifierValue : ItemModifierValue<int>
    {
        public override float ApplyModifier(float targetValue)
        {
            return 0;
        }
    }
}