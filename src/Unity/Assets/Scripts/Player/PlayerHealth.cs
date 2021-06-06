using UnityEngine;

namespace Player
{
    public class PlayerHealth : MonoBehaviour
    {
        public float MAXHEALTH = 100f;
        public float currentHealth;
        public GameObject DeathMenu;

        private void Start()
        {
            currentHealth = MAXHEALTH;
        }
        public void TakeDamage(float damage)
        {
            currentHealth -= damage;
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
    }
}
