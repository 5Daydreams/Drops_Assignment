using System;
using UnityEngine;

namespace _Code
{
    [CreateAssetMenu(menuName = "ItemDropPool/ModifierValue/Integer Explicit")]
    public class IntExplicitModifierValue : ItemModifierValue<int>
    {
        public override float ApplyModifier(float targetValue)
        {
            return 0;
        }
    }
}