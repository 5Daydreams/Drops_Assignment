using _Code;
using UnityEditor;
using UnityEngine;

namespace _Tools.Editor
{
    public class ArmourStatsWindowEditor : EditorWindow
    {
        public SerializedObject So;
        public SerializedProperty PropArmourStat;
        public SerializedProperty PropArmourValue;
        public SerializedProperty PropEvasionStat;
        public SerializedProperty PropEvasionValue;
        public SerializedProperty PropEnergyShieldStat;
        public SerializedProperty PropEnergyShieldValue;

        public static void Open(WeaponStats weaponStats)
        {
            WeaponStatsWindowEditor window = GetWindow<WeaponStatsWindowEditor>("Weapon Stats Window");
            window.So = new SerializedObject(weaponStats);
        }
        
        private void OnEnable()
        {
            PropArmourStat = So.FindProperty("Armour.AssociatedStat");
            PropArmourValue = So.FindProperty("Armour.AssociatedStatValue");
            PropEvasionStat = So.FindProperty("Evasion.AssociatedStat");
            PropEvasionValue = So.FindProperty("Evasion.AssociatedStatValue");
            PropEnergyShieldStat = So.FindProperty("EnergyShield.AssociatedStat");
            PropEnergyShieldValue = So.FindProperty("EnergyShield.AssociatedStatValue");
        }

        public void OnGUI()
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