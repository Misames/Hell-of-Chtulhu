using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextUpdater : MonoBehaviour
{
    private TextStorage textStorage;
    private TextMeshProUGUI textComponent;

    // Start is called before the first frame update
    void Start()
    {
        textStorage = gameObject.GetComponent<TextStorage>();
        textComponent = gameObject.GetComponent<TextMeshProUGUI>();
        updateText();
    }

    void Update()
    {
        updateText();
    }

    void updateText()
    {
        textComponent.SetText(textStorage.getText());
    }
}
