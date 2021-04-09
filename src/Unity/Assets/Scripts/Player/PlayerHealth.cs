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
        }
        public void TakeDamage(float damage)
        {
            currentHealth -= damage;

            // Si plus de vie affiche le menu de mort
            if (currentHealth <= 0)
            {
                Time.timeScale = 0;
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                DeathMenu.SetActive(true);
            }
        }

        private void Restart()
        {
            currentHealth = MAXHEALTH;
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.J)) this.TakeDamage(20);
        }
    }
}
