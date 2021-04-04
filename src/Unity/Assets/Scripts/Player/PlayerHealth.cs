using UnityEngine;

namespace Player
{
    public class PlayerHealth : MonoBehaviour
    {
        public float MAXHEALTH = 100f;
        public float currentHealth;

        public HealthBar healthBar;

        private void Start()
        {
            currentHealth = MAXHEALTH;
            healthBar.SetMaxHeath(MAXHEALTH);
        }
        public void TakeDamage(float damage)
        { 
                currentHealth -= damage;
                Debug.Log(currentHealth);
                if (!(currentHealth <= 0)) return;
                currentHealth = 0;
                
                Restart();
            
        }

        private void Restart()
        {
            currentHealth = MAXHEALTH;
        }

    }
}
