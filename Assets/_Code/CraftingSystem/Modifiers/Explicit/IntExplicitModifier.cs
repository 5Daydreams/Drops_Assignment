using UnityEngine;

namespace _Code
{
    [CreateAssetMenu(menuName = "ItemDropPool/Modifier/Explicit")]
    public class IntExplicitModifier : ItemModifier<IntExplicitModifierValue,int>
    {
        public string Name;
    }
}