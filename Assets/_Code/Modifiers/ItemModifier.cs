using UnityEngine;

namespace _Code
{
    public abstract class ItemModifier<T> : ScriptableObject where T : ItemModifierValue
    {
        public T[] ModifierValues;
    }
}