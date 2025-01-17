﻿using UnityEngine;
using System;

public class TextStorage : MonoBehaviour
{
    private TextManager.TextDict[] textStorage;
    private string text;
    private string currentLang;
    public string textKey;

    private void Start()
    {
        currentLang = GameObject.Find("language").GetComponent<LanguageManager>().language;
        textStorage = GameObject.Find("language").GetComponent<TextManager>().getText(textKey);
    }

    public string getText()
    {
        if (textKey != null)
            textStorage = GameObject.Find("language").GetComponent<TextManager>().getText(textKey);

        currentLang = GameObject.Find("language").GetComponent<LanguageManager>().language;
        int i = 0;
        while (i < textStorage.Length)
        {
            if (String.Equals(textStorage[i].language, currentLang))
                return textStorage[i].text;
            i += 1;
        }
        return "error";
    }
}
