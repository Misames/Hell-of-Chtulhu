﻿using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;

public class MenuManager : MonoBehaviour
{
    public AudioMixer mainMixer;
    public Dropdown resolutionDropdown;
    private Resolution[] resolutions;
    public GameObject form;
    public GameObject bg;
    private string pseudo;
    private string mdp;
    public LanguageManager managerLangue;

    private void Start()
    {
        PlayerPrefs.SetInt("load", 0);
        Time.timeScale = 1;
        resolutions = Screen.resolutions;
        resolutionDropdown.ClearOptions();
        List<string> options = new List<string>();
        int currentResolutionIndex = 0;
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);
            if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
                currentResolutionIndex = i;
        }
        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
    }

    private void Awake()
    {
        if (PlayerPrefs.GetString("lang") == "")
            PlayerPrefs.SetString("lang", "en");
    }

    public void LogIn()
    {
        StartCoroutine(getPlayer("https://site-hell-of-cthulhu.azurewebsites.net/api.php?action=get_player&pseudo=" + this.pseudo + "&mdp=" + this.mdp));
    }

    IEnumerator getPlayer(string url)
    {
        UnityWebRequest uwr = UnityWebRequest.Get(url);
        yield return uwr.SendWebRequest();
        if (uwr.downloadHandler.text != "false")
        {
            Score myObject = JsonUtility.FromJson<Score>(uwr.downloadHandler.text); ;
            PlayerPrefs.SetString("Nickname", this.pseudo);
            form.SetActive(false);
            bg.SetActive(true);
        }
        else
        {
            form.SetActive(true);
            bg.SetActive(false);
        }
    }

    public void UpdatePseudo(string s)
    {
        this.pseudo = s;
    }

    public void UpdateMdp(string s)
    {
        this.mdp = s;
    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    public void SetFullScreen(bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;
    }

    public void SetVolume(float volume)
    {
        mainMixer.SetFloat("volume", volume);
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void LoadParty()
    {
        if (PlayerPrefs.HasKey("x"))
        {
            PlayerPrefs.SetInt("load", 1);
            SceneManager.LoadScene(PlayerPrefs.GetString("scene"));
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}