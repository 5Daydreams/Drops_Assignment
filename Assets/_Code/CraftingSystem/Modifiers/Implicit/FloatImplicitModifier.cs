using UnityEngine;

namespace _Code
{
    
    [CreateAssetMenu(menuName = "ItemDropPool/ModifierValue/Float Implicit")]
    public class FloatImplicitModifier : ItemModifierValue<float>
    {
        public override float ApplyModifier(float targetValue)
        {
            return 0;
        }
    }
    
}