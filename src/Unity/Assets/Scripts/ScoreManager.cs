using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public int score = 0;
    float secElapsed = 0f;
    float minElapsed = 0f;
    public TextMeshProUGUI textUI;
    public TextMeshProUGUI timeUI;
    public void IncreaseScore()
    {
        score += 100;
        textUI.text = "Score " + this.score;
    }

    private void Update()
    {
        secElapsed += Time.deltaTime;
        if(secElapsed >= 59)
        {
            minElapsed += 1f;
            secElapsed = 0f;
        }
        timeUI.text = Mathf.Round(minElapsed).ToString("00") + ":" + Mathf.Round(secElapsed).ToString("00"); ;
    }
}
