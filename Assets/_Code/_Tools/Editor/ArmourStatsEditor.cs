using _Code;
using UnityEditor;
using UnityEngine;

namespace _Tools.Editor
{
    [CustomEditor(typeof(ArmourStats))]
    public class ArmourStatsEditor : UnityEditor.Editor
    {
        public SerializedObject So;
        public SerializedProperty PropArmourStat;
        public SerializedProperty PropArmourValue;
        public SerializedProperty PropEvasionStat;
        public SerializedProperty PropEvasionValue;
        public SerializedProperty PropEnergyShieldStat;
        public SerializedProperty PropEnergyShieldValue;

        private void OnEnable()
        {
            So = serializedObject;

            PropArmourStat = So.FindProperty("Armour.AssociatedStat");
            PropArmourValue = So.FindProperty("Armour.AssociatedStatValue");
            PropEvasionStat = So.FindProperty("Evasion.AssociatedStat");
            PropEvasionValue = So.FindProperty("Evasion.AssociatedStatValue");
            PropEnergyShieldStat = So.FindProperty("EnergyShield.AssociatedStat");
            PropEnergyShieldValue = So.FindProperty("EnergyShield.AssociatedStatValue");
        }

        public override void OnInspectorGUI()
        {
            So.Update();

            EditorGUILayout.Separator();
            LabeledPropertyField(PropArmourStat);
            LabeledPropertyField(PropArmourValue);
            EditorGUILayout.Separator();
            LabeledPropertyField(PropEvasionStat);
            LabeledPropertyField(PropEvasionValue);
            EditorGUILayout.Separator();
            LabeledPropertyField(PropEnergyShieldStat);
            LabeledPropertyField(PropEnergyShieldValue);

            So.ApplyModifiedProperties();
        }

        private void LabeledPropertyField(SerializedProperty prop)
        {
            var label = prop.propertyPath.Replace(".Associated", " ");
            EditorGUILayout.PropertyField(prop, new GUIContent(label));
        }
    }
}