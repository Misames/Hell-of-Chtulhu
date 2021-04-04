using UnityEngine;

namespace Player
{
    public class PlayerHealth : MonoBehaviour
    {
        public float MAXHEALTH = 100f;
        public float currentHealth;
        public HealthBar healthBar;
        public GameObject DeathMenu;
        private void Start()
        {
            // initialise la vie et la HealBar du Player
            currentHealth = MAXHEALTH;
            healthBar.SetMaxHeath(MAXHEALTH);
        }
        public void TakeDamage(float damage)
        {
            currentHealth -= damage;
            healthBar.SetHeath(currentHealth);

            // Si plus de vie affiche le menu de mort
            if (currentHealth <= 0)
            {
                DeathMenu.SetActive(true);
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                Time.timeScale = 0;
            }
        }

        private void Restart()
        {
            currentHealth = MAXHEALTH;
        }
    }
}
