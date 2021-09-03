using System;
using System.Linq;
using System.Reflection;
using _Code;
using UnityEditor;
using UnityEngine;

namespace _Tools.Editor
{
    // [CustomEditor(typeof(WeaponStats))]
    // public class WeaponStatsEditor : UnityEditor.Editor
    // {
    //     public SerializedObject So;
    //     public SerializedProperty PropMinDamageStat;
    //     public SerializedProperty PropMinDamageValue;
    //     public SerializedProperty PropMaxDamageStat;
    //     public SerializedProperty PropMaxDamageValue;
    //     public SerializedProperty PropCriticalStrikeChanceStat;
    //     public SerializedProperty PropCriticalStrikeChanceValue;
    //     public SerializedProperty PropAttackSpeedStat;
    //     public SerializedProperty PropAttackSpeedValue;
    //     public SerializedProperty PropRangeStat;
    //     public SerializedProperty PropRangeValue;
    //
    //     private void OnEnable()
    //     {
    //         So = serializedObject;
    //         PropMinDamageStat = So.FindProperty("MinDamage.AssociatedStat");
    //         PropMinDamageValue = So.FindProperty("MinDamage.AssociatedStatValue");
    //         PropMaxDamageStat = So.FindProperty("MaxDamage.AssociatedStat");
    //         PropMaxDamageValue = So.FindProperty("MaxDamage.AssociatedStatValue");
    //         PropCriticalStrikeChanceStat = So.FindProperty("CriticalStrikeChance.AssociatedStat");
    //         PropCriticalStrikeChanceValue = So.FindProperty("CriticalStrikeChance.AssociatedStatValue");
    //         PropAttackSpeedStat = So.FindProperty("AttacksPerSecond.AssociatedStat");
    //         PropAttackSpeedValue = So.FindProperty("AttacksPerSecond.AssociatedStatValue");
    //         PropRangeStat = So.FindProperty("Range.AssociatedStat");
    //         PropRangeValue = So.FindProperty("Range.AssociatedStatValue");
    //     }
    //
    //     public override void OnInspectorGUI()
    //     {
    //         So.Update();
    //         
    //         EditorGUILayout.Separator();
    //         LabeledPropertyField(PropMinDamageStat);
    //         LabeledPropertyField(PropMinDamageValue);
    //         EditorGUILayout.Separator();
    //         LabeledPropertyField(PropMaxDamageStat);
    //         LabeledPropertyField(PropMaxDamageValue);
    //         EditorGUILayout.Separator();
    //         LabeledPropertyField(PropCriticalStrikeChanceStat);
    //         LabeledPropertyField(PropCriticalStrikeChanceValue);
    //         EditorGUILayout.Separator();
    //         LabeledPropertyField(PropAttackSpeedStat);
    //         LabeledPropertyField(PropAttackSpeedValue);
    //         EditorGUILayout.Separator();
    //         LabeledPropertyField(PropRangeStat);
    //         LabeledPropertyField(PropRangeValue);
    //         
    //         serializedObject.ApplyModifiedProperties();
    //     }
    //
    //     private void LabeledPropertyField(SerializedProperty prop)
    //     {
    //         var label = prop.propertyPath.Replace(".Associated"," ");
    //         EditorGUILayout.PropertyField(prop,new GUIContent(label));
    //     }
    // }
}