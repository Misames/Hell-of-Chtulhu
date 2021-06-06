using UnityEngine;
using System;
using System.IO;

public class TextManager : MonoBehaviour
{
    [Serializable]
    public struct TextDict
    {
        public string language;
        public string text;
    }
    [Serializable]
    public struct TextDictionary
    {
        public string key;
        public TextDict[] texts;
    }
    public TextDictionary[] textList;

    // Start is called before the first frame update
    void Start()
    {
        textList = CreateFromJSON(ReadString());
    }

    void OnApplicationQuit()
    {
        WriteString();
    }

    void WriteString()
    {
        string path = "Assets/Scripts/Translate/language.json";
        StreamWriter writer = new StreamWriter(path, false);
        writer.WriteLine(SaveToString());
        writer.Close();
    }

    static string ReadString()
    {
        string path = "Assets/Scripts/Translate/language.json";
        StreamReader reader = new StreamReader(path);
        string text = reader.ReadToEnd();
        reader.Close();
        return text;
    }

    static TextDictionary[] CreateFromJSON(string jsonString)
    {
        return JsonHelper.FromJson<TextDictionary>(jsonString);
    }

    public string SaveToString()
    {
        return JsonHelper.ToJson<TextDictionary>(textList, true);
    }

    public TextDict[] getText(string textName)
    {
        int i = 0;
        while (i < textList.Length)
        {
            if (String.Equals(textList[i].key, textName))
            {
                return textList[i].texts;
            }
            i += 1;
        }
        return null;
    }
}

public static class JsonHelper
{
    public static T[] FromJson<T>(string json)
    {
        Wrapper<T> wrapper = JsonUtility.FromJson<Wrapper<T>>(json);
        return wrapper.Items;
    }

    public static string ToJson<T>(T[] array)
    {
        Wrapper<T> wrapper = new Wrapper<T>();
        wrapper.Items = array;
        return JsonUtility.ToJson(wrapper);
    }

    public static string ToJson<T>(T[] array, bool prettyPrint)
    {
        Wrapper<T> wrapper = new Wrapper<T>();
        wrapper.Items = array;
        return JsonUtility.ToJson(wrapper, prettyPrint);
    }

    [Serializable]
    private class Wrapper<T>
    {
        public T[] Items;
    }
}
