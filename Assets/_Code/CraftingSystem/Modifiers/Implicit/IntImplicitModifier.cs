using UnityEngine;

namespace _Code
{
    [CreateAssetMenu(menuName = "ItemDropPool/Modifier/Implicit")]
    public class IntImplicitModifier : ItemModifier<IntImplicitModifierValue,int>
    {
        public void Method()
        {
            // float thing = ModifierValues[0].ModTargetStat;
        }
    }
}