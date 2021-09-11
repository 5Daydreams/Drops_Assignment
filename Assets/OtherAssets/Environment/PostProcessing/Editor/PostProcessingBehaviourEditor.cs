using System;
using System.Linq.Expressions;
using OtherAssets.Environment.PostProcessing.Editor.Utils;
using OtherAssets.Environment.PostProcessing.Runtime;
using UnityEditor;

namespace OtherAssets.Environment.PostProcessing.Editor
{
    [CustomEditor(typeof(PostProcessingBehaviour))]
    public class PostProcessingBehaviourEditor : UnityEditor.Editor
    {
        SerializedProperty m_Profile;

        public void OnEnable()
        {
            m_Profile = FindSetting((PostProcessingBehaviour x) => x.profile);
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            EditorGUILayout.PropertyField(m_Profile);

            serializedObject.ApplyModifiedProperties();
        }

        SerializedProperty FindSetting<T, TValue>(Expression<Func<T, TValue>> expr)
        {
            return serializedObject.FindProperty(ReflectionUtils.GetFieldPath(expr));
        }
    }
}
