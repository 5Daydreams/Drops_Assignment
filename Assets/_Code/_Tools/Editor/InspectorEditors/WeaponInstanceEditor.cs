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
        public SerializedProperty PropWeaponIntStats;
        public SerializedProperty PropWeaponFloatStats;


        private void OnEnable()
        {
            So = new SerializedObject(((WeaponBaseData) ((WeaponInstance) target).BaseData).Stats);
            So2 = new SerializedObject(((WeaponInstance) target).BaseData);

            PropName = So2.FindProperty("Name");
            PropWeaponIntStats = So.FindProperty("WeaponIntStats");
            PropWeaponFloatStats = So.FindProperty("WeaponFloatStats");
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

                EditorGUI.indentLevel+=2;
                EditorGUILayout.PropertyField(PropWeaponIntStats);
                EditorGUILayout.PropertyField(PropWeaponFloatStats);
                EditorGUI.indentLevel-=2;
            }

            So.ApplyModifiedProperties();
        }
    }
}