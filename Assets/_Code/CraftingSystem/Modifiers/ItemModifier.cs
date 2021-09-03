using System;
using UnityEngine;

namespace _Code
{
    public abstract class ItemModifier<T,J> : ScriptableObject where T : ItemModifierValue<J>
    {
        public T[] ModifierValues;
    }
}