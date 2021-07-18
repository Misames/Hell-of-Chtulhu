using UnityEngine;

public class LanguageManager : MonoBehaviour
{
    public string language = "en";

    public void changeLang(int lang)
    {
        if (lang == 1)
        {
            PlayerPrefs.SetString("lang", "fr");
        }
        else
        {
            PlayerPrefs.SetString("lang", "en");
        }
    }

    private void Update()
    {
        language = PlayerPrefs.GetString("lang");
    }
}
