using Player;
using UnityEngine;
using UnityEngine.UI;
public class HealthBar : MonoBehaviour
{
    public Slider slider;
    public PlayerHealth playerHealth;
    public Gradient gradient;
    public Image fill;
    
    
    void Awake()
    {
        slider.maxValue = playerHealth.MAXHEALTH;
        slider.value = slider.maxValue;
        fill.color = gradient.Evaluate(1f);
    }

    public void SetHeath(float health)
    {
        slider.value = playerHealth.currentHealth;
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            currentHealth -= 20;
            this.SetHeath(currentHealth);
        }

    }

}
