using UnityEngine;

namespace _Code
{
    [CreateAssetMenu(menuName = "ItemDropPool/Modifier/Float")]
    public class Modifier : ScriptableObject
    {
        public ModifierValue[] ModifierValues;
    }
}
