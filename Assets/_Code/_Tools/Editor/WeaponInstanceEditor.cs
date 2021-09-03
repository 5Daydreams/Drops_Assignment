using System;
using _Code;
using _Code.BaseTypeGroups;
using UnityEditor;
using UnityEngine;

namespace _Tools.Editor
{
    [CustomEditor(typeof(WeaponInstance))]
    public class WeaponInstanceEditor : UnityEditor.Editor
    {
        public SerializedObject So;
        public SerializedObject So2;
        public SerializedProperty PropName;
        public SerializedProperty PropMinDamageStatValue;
        public SerializedProperty PropMaxDamageStatValue;
        public SerializedProperty PropCriticalStrikeChanceStatValue;
        public SerializedProperty PropAttacksPerSecondStatValue;
        public SerializedProperty PropRangeStatValue;


        private void OnEnable()
        {
            So = new SerializedObject(((WeaponBaseData) ((WeaponInstance) target).BaseData).Stats);
            So2 = new SerializedObject(((WeaponInstance) target).BaseData);

            PropName = So2.FindProperty("Name");
            PropMinDamageStatValue = So.FindProperty("MinDamage.AssociatedStatValue");
            PropMaxDamageStatValue = So.FindProperty("MaxDamage.AssociatedStatValue");
            PropCriticalStrikeChanceStatValue = So.FindProperty("CriticalStrikeChance.AssociatedStatValue");
            PropAttacksPerSecondStatValue = So.FindProperty("AttacksPerSecond.AssociatedStatValue");
            PropRangeStatValue = So.FindProperty("Range.AssociatedStatValue");
        }

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            So.Update();


            using (new EditorGUILayout.VerticalScope(EditorStyles.helpBox))
            {
                EditorGUILayout.Separator();

                using (new EditorGUILayout.HorizontalScope())
                {
                    var label = PropName.propertyPath.Replace(".AssociatedStatValue", "");
                    EditorGUILayout.LabelField(label);
                    EditorGUILayout.LabelField(PropName.stringValue);
                }

                EditorGUILayout.Separator();
                using (new EditorGUILayout.HorizontalScope())
                {
                    EditorGUILayout.LabelField("Physical Damage");
                    EditorGUILayout.LabelField(PropMinDamageStatValue.intValue + " to " +
                                               PropMaxDamageStatValue.intValue);
                }

                EditorGUILayout.Separator();
                using (new EditorGUILayout.HorizontalScope())
                {
                    var label = PropCriticalStrikeChanceStatValue.propertyPath.Replace(".AssociatedStatValue", "");
                    EditorGUILayout.LabelField(label);
                    EditorGUILayout.LabelField(PropCriticalStrikeChanceStatValue.floatValue + "%");
                }

                EditorGUILayout.Separator();
                FloatLabeledPropertyField(PropAttacksPerSecondStatValue);
                EditorGUILayout.Separator();
                IntLabeledPropertyField(PropRangeStatValue);
            }


            So.ApplyModifiedProperties();
        }

        private void FloatLabeledPropertyField(SerializedProperty prop)
        {
            using (new EditorGUILayout.HorizontalScope())
            {
                var label = prop.propertyPath.Replace(".AssociatedStatValue", "");
                EditorGUILayout.LabelField(label);
                EditorGUILayout.LabelField(prop.floatValue.ToString());
            }
        }

        private void IntLabeledPropertyField(SerializedProperty prop)
        {
            using (new EditorGUILayout.HorizontalScope())
            {
                var label = prop.propertyPath.Replace(".AssociatedStatValue", "");
                EditorGUILayout.LabelField(label);
                EditorGUILayout.LabelField(prop.intValue.ToString());
            }
        }
    }
}