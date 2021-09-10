using System;
using UnityEngine;

namespace _Code.ModifierOperations
{
    public abstract class ModifierOperationType : ScriptableObject
    {
        public abstract Func<float,float,float> GetOperation();
    }
}