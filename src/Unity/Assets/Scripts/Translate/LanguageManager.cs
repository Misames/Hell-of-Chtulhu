using UnityEngine;

public class LanguageManager : MonoBehaviour
{
    public string language = "en";

    public void changeLang(int lang)
    {
        if (lang == 1)
        {
            language = "fr";
        }
        else
        {
            language = "en";
        }
    }
}
