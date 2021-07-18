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

    private TextDictionary[] textList;

    void readJson()
    {
        textList = CreateFromJSON(ReadString());
    }

    static string ReadString()
    {
        string path = Application.streamingAssetsPath + "/language.json";

#if UNITY_EDITOR
        path = "Assets/StreamingAssets/language.json";
#endif
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
        readJson();
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
