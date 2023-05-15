#nullable enable

using UnityEditor;
    
namespace Hagans.Ecs.SystemInitialization.Editor
{
    [CustomEditor(typeof(SystemInitializationSettings))]
    public class SystemInitializationSettingsEditor : Editor
    {
        SerializedProperty _settings;
        private void OnEnable()
        {
            _settings = serializedObject.FindProperty("_settings");
        }

        public override void OnInspectorGUI()
        {
            for(int i = 0; i < _settings.arraySize; i++)
            {
                var prop = _settings.GetArrayElementAtIndex(i);
                var active = prop.FindPropertyRelative("_active");

                EditorGUIUtility.labelWidth = EditorGUIUtility.currentViewWidth - EditorGUIUtility.fieldWidth;

                var res = EditorGUILayout.Toggle(prop.FindPropertyRelative("_name").stringValue, active.boolValue);

                if (active.boolValue != res)
                {                
                    active.boolValue = res;
                    serializedObject.ApplyModifiedProperties();
                }
            }
        }
    } 
}
