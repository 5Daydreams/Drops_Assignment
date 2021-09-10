using _Code;
using _Code.AssignmentRelated.DropSystem._3_ItemBase.BaseTypeData;
using UnityEditor;
using UnityEngine;

namespace _Tools.Editor
{
    [CanEditMultipleObjects]
    [CustomEditor(typeof(EquipmentStats))]
    public class EquipmentStatsEditor : UnityEditor.Editor
    {
        public SerializedObject So;
        public SerializedObject So2;
        public SerializedProperty PropName;
        public SerializedProperty PropEquipmentBaseStats;

        private void OnEnable()
        {
            So = new SerializedObject(((EquipmentStats) target).BaseStats);
            So2 = new SerializedObject((EquipmentStats) target);

            PropName = So2.FindProperty("Name");
            PropEquipmentBaseStats = So.FindProperty("EquipmentBaseStats");
        }

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            if (GUILayout.Button("RollImplicitModifierValues"))
            {
                ((EquipmentStats) target).RollImplicitModifierValues();
            }
            
            if (GUILayout.Button("RollExplicitModifierValues"))
            {
                ((EquipmentStats) target).RollExplicitModifierValues();
            }

            So.Update();

            using (new EditorGUILayout.VerticalScope(EditorStyles.helpBox))
            {
                EditorGUILayout.Separator();
                using (new EditorGUILayout.HorizontalScope())
                {
                    var label = PropName.propertyPath;
                    EditorGUILayout.LabelField(label);
                    EditorGUILayout.LabelField(PropName.stringValue);
                }

                EditorGUILayout.Separator();
                EditorGUI.indentLevel += 2;
                EditorGUILayout.PropertyField(PropEquipmentBaseStats);
                EditorGUI.indentLevel -= 2;
            }

            So.ApplyModifiedProperties();
        }
    }
}