using System;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    public static int score = 0;
    public TextMeshProUGUI textUI;
    public static void IncreaseScore(int value=100)
    {
        Score.score += value;
        

    }

    private void Update()
    {
        Debug.Log(score);
        textUI.text = $"{Score.score}";
    }
}
