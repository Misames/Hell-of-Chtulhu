using UnityEngine;
using UnityEditor;

namespace Editor
{
    public class GenerateMapWindow : EditorWindow
    {
        private GenerateMapSettings settings;
        private void OnGUI()
        {
            if (settings == null)
            {
                settings = null;
            }

            EditorGUILayout.BeginVertical();
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("Un champ d'information");
            EditorGUILayout.EndVertical();
        }
    }
}
