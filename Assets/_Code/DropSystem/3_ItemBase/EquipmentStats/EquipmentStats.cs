using System;
using _Code.StatSystem;
using UnityEngine;

namespace _Code
{
    public abstract class EquipmentStats : ScriptableObject
    {
        
    }

    [Serializable]
    public struct StatValue<T>
    {
        public StatTag AssociatedStat;
        public T AssociatedStatValue;
    }
}