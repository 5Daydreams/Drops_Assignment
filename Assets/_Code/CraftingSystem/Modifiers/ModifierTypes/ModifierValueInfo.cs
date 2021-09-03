using System;
using UnityEngine;

namespace _Code.ModifierOperations
{
    public abstract class ModifierValueInfo : ScriptableObject
    {
        public abstract Func<float,float,float> GetOperation();

        public abstract float GetMinValue();
        public abstract float GetMaxValue();
        public abstract float GetRandomValueByTier(int tier);
    }
}