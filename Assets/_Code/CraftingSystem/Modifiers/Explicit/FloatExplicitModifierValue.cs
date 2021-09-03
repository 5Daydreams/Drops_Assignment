using UnityEngine;

namespace _Code
{
    [CreateAssetMenu(menuName = "ItemDropPool/ModifierValue/Float Explicit")]
    public class FloatExplicitModifierValue : ItemModifierValue<float>
    {
        public override float ApplyModifier(float targetValue)
        {
            return 0;
        }
    }
}