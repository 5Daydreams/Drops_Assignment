using System;
using _Code.ModifierOperations;
using UnityEngine;

namespace _Code
{
    public abstract class ItemModifierValue<T> : ScriptableObject
    {
        // protected int tier;

        public StatValue<T> ModTargetStat;
        public ModifierValueInfo modValueInfoOperation;

        public abstract float ApplyModifier(float targetValue);
    }
}