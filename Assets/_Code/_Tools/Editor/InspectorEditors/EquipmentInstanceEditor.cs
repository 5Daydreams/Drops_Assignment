using _Code;
using UnityEditor;

namespace _Tools.Editor
{
    [CanEditMultipleObjects]
    [CustomEditor(typeof(EquipmentInstance))]
    public class EquipmentInstanceEditor : UnityEditor.Editor
    {
        public SerializedObject So;
        public SerializedProperty PropName;
        public SerializedProperty PropEquipmentBaseStats;


        private void OnEnable()
        {
            So = new SerializedObject(((EquipmentInstance) target).BaseData);
            
            PropName = So.FindProperty("Name");
            PropEquipmentBaseStats = So.FindProperty("EquipmentBaseStats");
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

                EditorGUI.indentLevel += 2;
                EditorGUILayout.PropertyField(PropEquipmentBaseStats);
                EditorGUI.indentLevel -= 2;
            }

            So.ApplyModifiedProperties();
        }
    }
}