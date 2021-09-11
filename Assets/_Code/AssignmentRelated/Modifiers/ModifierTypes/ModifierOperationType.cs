using System;
using UnityEngine;

namespace _Code.AssignmentRelated.Modifiers.ModifierTypes
{
    public abstract class ModifierOperationType : ScriptableObject
    {
        public abstract Func<float,float,float> GetOperation();
    }
}