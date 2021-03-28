using UnityEngine;
using TMPro;
public class Score : MonoBehaviour
{

    private int score = 0;
    public TextMeshProUGUI textUI;

    public void IncreaseScore()
    {
        score += 100;
        textUI.text = $"Score {score}";
    }
}
