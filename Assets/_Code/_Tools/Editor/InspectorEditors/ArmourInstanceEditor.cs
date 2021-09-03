using _Code;
using _Code.BaseTypeGroups;
using UnityEditor;

namespace _Tools.Editor
{
    [CustomEditor(typeof(ArmourInstance))]
    public class ArmourInstanceEditor : UnityEditor.Editor
    {
        public SerializedObject So;
        public SerializedObject So2;
        public SerializedProperty PropName;
        public SerializedProperty PropArmourStateValue;
        public SerializedProperty PropEvasionStatValue;
        public SerializedProperty PropEnergyShieldStatValue;

        private void OnEnable()
        {
            So = new SerializedObject(((ArmourBaseData) ((ArmourInstance) target).BaseData).Stats);
            So2 = new SerializedObject(((ArmourInstance) target).BaseData);

            PropName = So2.FindProperty("Name");
            PropArmourStateValue = So.FindProperty("Armour.AssociatedStatValue");
            PropEvasionStatValue = So.FindProperty("Evasion.AssociatedStatValue");
            PropEnergyShieldStatValue = So.FindProperty("EnergyShield.AssociatedStatValue");
        }

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            So.Update();
            
            using (new EditorGUILayout.VerticalScope(EditorStyles.helpBox))
            {
                StringLabeledPropertyField(PropName);
                IntLabeledPropertyField(PropArmourStateValue);
                IntLabeledPropertyField(PropEvasionStatValue);
                IntLabeledPropertyField(PropEnergyShieldStatValue);
            }


            So.ApplyModifiedProperties();
        }

        private void IntLabeledPropertyField(SerializedProperty prop)
        {
            EditorGUILayout.Separator();
            using (new EditorGUILayout.HorizontalScope())
            {
                var label = prop.propertyPath.Replace(".AssociatedStatValue", "");
                EditorGUILayout.LabelField(label);
                EditorGUILayout.LabelField(prop.intValue.ToString());
            }
        }
        
        private void StringLabeledPropertyField(SerializedProperty prop)
        {
            EditorGUILayout.Separator();
            using (new EditorGUILayout.HorizontalScope())
            {
                var label = prop.propertyPath.Replace(".AssociatedStatValue", "");
                EditorGUILayout.LabelField(label);
                EditorGUILayout.LabelField(prop.stringValue);
            }
        }
    }
}