using UnityEngine;
using TMPro;

public class TextUpdater : MonoBehaviour
{
    private TextStorage textStorage;
    private TextMeshProUGUI textComponent;

    private void Start()
    {
        textStorage = gameObject.GetComponent<TextStorage>();
        textComponent = gameObject.GetComponent<TextMeshProUGUI>();
        updateText();
    }

    private void Update()
    {
        updateText();
    }

    private void updateText()
    {
        textComponent.SetText(textStorage.getText());
    }
}
