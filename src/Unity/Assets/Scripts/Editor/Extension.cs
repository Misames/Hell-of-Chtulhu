using UnityEditor;
using UnityEngine;

namespace Editor
{
    public class Extension : UnityEditor.Editor
    {
        [MenuItem("Extensions/GameDesign")]
        public static void ShowBrokenReferences()
        {
            Debug.Log("ouvre une fenetre avec la liste des variables à tweak");
        }
    }

}
