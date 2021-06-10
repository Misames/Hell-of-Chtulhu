using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;
using TMPro;

public class GameManager : MonoBehaviour
{
    private bool isPause = false;
    private int score = 0;
    private string time;
    private float secElapsed = 0f;
    private float minElapsed = 0f;
    public TextMeshProUGUI timeUI;
    public TextMeshProUGUI scoreUI;
    public GameObject pauseMenu;
    public GameObject winScreen;

    private void Update()
    {
        if (Input.GetKey(KeyCode.F)) IncreaseScore();
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPause) ResumeGame();
            else PauseGame();
        }

        secElapsed += Time.deltaTime;

        if (secElapsed >= 59)
        {
            minElapsed += 1f;
            secElapsed = 0f;
        }

        time = Mathf.Round(minElapsed).ToString("00") + ":" + Mathf.Round(secElapsed).ToString("00");
        timeUI.text = time;
    }

    public void PauseGame()
    {
        pauseMenu.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Time.timeScale = 0f;
        isPause = true;
        GameObject.Find("WeaponHolder").GetComponent<WeaponSwitching>().enabled = false;
    }

    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Time.timeScale = 1f;
        isPause = false;
        GameObject.Find("WeaponHolder").GetComponent<WeaponSwitching>().enabled = true;
    }

    public void GoToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void GoToOption()
    {
        // set non-visible l'UI PauseMenu
        // set visible le GameObject qui contnient mon UI OPTION
    }

    public void IncreaseScore()
    {
        score += 100;
        scoreUI.text = $"{score}";
    }

    public void GameWin()
    {
        winScreen.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Time.timeScale = 0f;
        StartCoroutine(PostRun());
        score = 0;
    }

    IEnumerator PostRun()
    {
        WWWForm form = new WWWForm();
        form.AddField("nikname", "WiZaR");
        form.AddField("score", this.score);
        form.AddField("time", this.time);
        form.AddField("level", "1");
        using (UnityWebRequest www = UnityWebRequest.Post("http://hell-of-cthulhu/post", form))
        {
            yield return www.SendWebRequest();
            if (www.isNetworkError || www.isHttpError) Debug.Log(www.error);
            else Debug.Log("Form upload complete!");
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
    }

    public void Leave()
    {
        SceneManager.LoadScene("MainMenu");
    }

}
