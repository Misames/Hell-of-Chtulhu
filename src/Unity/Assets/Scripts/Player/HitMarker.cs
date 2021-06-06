using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class HitMarker : MonoBehaviour
{
    public float displayTime = 0.3f;

    void Start()
    {
        Image img = gameObject.GetComponent<Image>();
        img.enabled = false;
    }

    void displayHitmarker()
    {
        StartCoroutine(displayHitmarkerRoutine());
    }

    IEnumerator displayHitmarkerRoutine()
    {
        Image img = gameObject.GetComponent<Image>();
        img.enabled = true;
        yield return new WaitForSeconds(0.3f);
        img.enabled = false;
    }
}
