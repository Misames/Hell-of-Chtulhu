using UnityEngine;
using UnityEngine.UI;
public class HealthBar : MonoBehaviour
{
    public HealthBar healthBar;
    public Slider slider;
    public int currentHealth;
    public Gradient gradient;
    public Image fill;
    public void SetMaxHeath(float Health)
    {
        slider.maxValue = Health;
        slider.value = Health;
        fill.color = gradient.Evaluate(1f);
    }

    public void SetHeath(float health)
    {
        slider.value = health;
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }

}
