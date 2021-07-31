using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;
    public PlayerHealth playerHealth;
    public Gradient gradient;
    public Image fill;

    private void Awake()
    {
        slider.maxValue = playerHealth.MAXHEALTH;
        slider.value = slider.maxValue;
        fill.color = gradient.Evaluate(1f);
    }

    public void Update()
    {
        slider.value = playerHealth.currentHealth;
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}
