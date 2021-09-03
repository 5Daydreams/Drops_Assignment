using System;
using UnityEngine;

namespace _Code
{
    [CreateAssetMenu(menuName = "ItemDropPool/ModifierValue/Explicit")]
    public class ExplicitModifierValue : ItemModifierValue
    {
        public override float ApplyModifier(float targetValue)
        {
            return 0;
        }
    }
}