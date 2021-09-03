using UnityEngine;

namespace _Code
{
    [CreateAssetMenu(menuName = "ItemDropPool/Modifier/Explicit")]
    public class ExplicitModifier : ItemModifier<ExplicitModifierValue>
    {
        public string Name;
    }
}