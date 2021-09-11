using _Code.AssignmentRelated.DropSystem._3_ItemBase.BaseTypeData;
using UnityEditor;
using UnityEngine;

namespace _Code._Tools.Editor.InspectorEditors
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

            if (GUILayout.Button("RerollItemRarity"))
            {
                ((EquipmentStats) target).RerollItemRarity();
            }
            
            if (GUILayout.Button("GetNewImplicitModifiers"))
            {
                ((EquipmentStats) target).GetNewImplicitModifiers();
            }

            if (GUILayout.Button("RollImplicitModifierValues"))
            {
                ((EquipmentStats) target).RerollImplicitModifierValues();
            }
            
            if (GUILayout.Button("GetNewExplicitModifiers"))
            {
                ((EquipmentStats) target).GetNewExplicitModifiers();
            }

            if (GUILayout.Button("RollExplicitModifierValues"))
            {
                ((EquipmentStats) target).RerollExplicitModifierValues();
            }
        }
    }
}