using UnityEngine;

namespace Player
{
    public class PlayerHealth : MonoBehaviour
    {
        public const int MAXHEALTH = 100;
        public int currentHealth;

        public HealthBar healthBar;

        private void Start()
        {
            currentHealth = MAXHEALTH;
            healthBar.SetMaxHeath(MAXHEALTH);
        }
        public void TakeDamage(int damage)
        {
            currentHealth -= damage;
            if (!(currentHealth <= 0)) return;
            currentHealth = 0;
            Debug.Log("mort");
            Restart();
        }

        private void Restart()
        {
            currentHealth = MAXHEALTH;
        }

    }
}
