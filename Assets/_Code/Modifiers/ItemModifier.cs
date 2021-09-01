using UnityEngine;

namespace _Code
{
    public abstract class ItemModifier : ScriptableObject
    {
        public string Name;
        public ItemModifierValue[] ModifierValues;
    }
}