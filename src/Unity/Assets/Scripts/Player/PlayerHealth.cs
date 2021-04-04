using UnityEngine;

namespace Player
{
    public class PlayerHealth : MonoBehaviour
    {
        public int MAXHEALTH = 100;
        public int currentHealth;
        public HealthBar healthBar;

        public Transform respawnPoint;
        public Transform player;
        private void Start()
        {
            currentHealth = MAXHEALTH;
            healthBar.SetMaxHeath(MAXHEALTH);
        }
        public void TakeDamage(int damage)
        {

            if (Input.GetKeyDown(KeyCode.O))
            {
                currentHealth -= 90;
            }

                currentHealth -= damage;
                if (currentHealth <= 0)
                {
                    currentHealth = 0;
                    Debug.Log("mort");
                    Restart();
                }
                
            
        }

        private void Restart()
        {
            player.transform.position = respawnPoint.transform.position;
            currentHealth = MAXHEALTH;
        }

    }
}
