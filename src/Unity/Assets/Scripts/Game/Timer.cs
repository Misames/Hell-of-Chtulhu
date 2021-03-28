using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    private float secElapsed = 0f;
    private float minElapsed = 0f;
    public TextMeshProUGUI timeUI;

    private void Update()
    {
        secElapsed += Time.deltaTime;
        if (secElapsed >= 59)
        {
            minElapsed += 1f;
            secElapsed = 0f;
        }
        timeUI.text = Mathf.Round(minElapsed).ToString("00") + ":" + Mathf.Round(secElapsed).ToString("00"); ;
    }
}
