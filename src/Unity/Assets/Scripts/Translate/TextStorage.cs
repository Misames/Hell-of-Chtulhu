using UnityEngine;
using System;

public class TextStorage : MonoBehaviour
{

    public TextManager.TextDict[] textStorage;
    public string textKey;

    private string text;
    private string currentLang;
    [SerializeField]
    private LanguageManager langManager;

    // Start is called before the first frame update
    void Start()
    {
        langManager = GameObject.Find("textManager").GetComponent<LanguageManager>();
        textStorage = GameObject.Find("textManager").GetComponent<TextManager>().getText(textKey);
        currentLang = langManager.language;
    }

    public string getText()
    {
        if (textKey != null)
        {
            textStorage = GameObject.Find("textManager").GetComponent<TextManager>().getText(textKey);
        }
        int i = 0;
        while (i < textStorage.Length)
        {
            if (String.Equals(textStorage[i].language, langManager.language))
            {
                return textStorage[i].text;
            }
            ++i;
        }
        return "error";
    }
}
