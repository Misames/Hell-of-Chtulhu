using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class GameManager : MonoBehaviour
{

    private bool isPause = false;
    // private bool gameHasEnded = false;
    // private string currentLvl = "";
    private int score = 0;
    private float secElapsed = 0f;
    private float minElapsed = 0f;
    public TextMeshProUGUI timeUI;
    public TextMeshProUGUI scoreUI;
    public GameObject pauseMenu;
    public GameObject winScreen;

    public void IncreaseScore()
    {
        score += 100;
        scoreUI.text = $"{score}";
    }

    public void GameOver()
    {
        // Affiche le menu de game over
    }

    public void GameWin()
    {
        // affiche le menu de win avec le score
        // propose de recommencer ou de passer au niveau suivant
        winScreen.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Time.timeScale = 0f;
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

    private void Update()
    {
        secElapsed += Time.deltaTime;
        if (secElapsed >= 59)
        {
            minElapsed += 1f;
            secElapsed = 0f;
        }
        timeUI.text = Mathf.Round(minElapsed).ToString("00") + ":" + Mathf.Round(secElapsed).ToString("00"); ;
        if (Input.GetKey(KeyCode.F)) IncreaseScore();
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            if (isPause) ResumeGame();
            else PauseGame();
        }

        // Condition de victoire
        if (score >= 10000) GameWin();
    }

    public void PauseGame()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isPause = true;
    }

    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isPause = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
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
}
