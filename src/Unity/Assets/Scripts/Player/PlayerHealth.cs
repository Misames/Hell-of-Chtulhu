using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float MAXHEALTH = 100f;
    public float currentHealth;

    private void Start()
    {
        currentHealth = MAXHEALTH;
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        Map.UpdateHealth(MAXHEALTH - currentHealth);
        if (currentHealth <= 0)
        {
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    public void HealPlayer(int amount)
    {
        if ((currentHealth + amount) > MAXHEALTH) currentHealth = MAXHEALTH;
        else currentHealth += amount;
    }

    private void Restart()
    {
        currentHealth = MAXHEALTH;
    }
}
