using UnityEditor;
using UnityEngine;

namespace Editor
{
    public class Extension : UnityEditor.Editor
    {
        [MenuItem("Extensions/CleanBrokenReferences")]
        public static void ShowBrokenReferences()
        {
            Debug.Log("Montre dans la scene actuel tous les GameObject où il manque des referances");
        }

        [MenuItem("Extensions/GenerateMap")]
        public static void GenerateMap()
        {
            var window = EditorWindow.GetWindow<GenerateMapWindow>();
            window.titleContent = new GUIContent("Generate Map Window");
            window.Show();
        }
    }

}
