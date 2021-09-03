using System;
using _Code.ModifierOperations;
using UnityEngine;

namespace _Code
{
    public abstract class ItemModifierValue : ScriptableObject
    {
        // protected int tier;

        public Stat ModTargetStat;
        public ModifierValueInfo modValueInfoOperation;

        public abstract float ApplyModifier(float targetValue);
    }


    public enum Stat
    {
        Life,
        Evasion,
        Armour,
        EnergyShield,
        PhysicalDamage,
        CriticalChance,
        AttackSpeed
    }
}