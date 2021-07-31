using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class HitMarker : MonoBehaviour
{
    public float displayTime = 0.3f;

    private void Start()
    {
        Image img = gameObject.GetComponent<Image>();
        img.enabled = false;
    }

    private void displayHitmarker()
    {
        StartCoroutine(displayHitmarkerRoutine());
    }

    IEnumerator displayHitmarkerRoutine()
    {
        Image img = gameObject.GetComponent<Image>();
        img.enabled = true;
        yield return new WaitForSeconds(displayTime);
        img.enabled = false;
    }
}
