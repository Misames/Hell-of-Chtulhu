using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Enemies
{
    public class Enemy : MonoBehaviour
    {
        public delegate void EnemyKilled();
        public static event EnemyKilled OnEnemyKilled;
        public float health = 100f;
        public GameObject healBox;
        public GameObject ammoBox;

        public void TakeDamage(float amount)
        {
            health -= amount;
            Debug.Log("life: "+health);
            
        }
        private void Die()
        {
            int spawnOnOff = Random.Range(0, 3);
            Score.IncreaseScore(100);
            switch (spawnOnOff)
            {
                case 0:
                    Instantiate(healBox, transform.position, Quaternion.identity);
                    break;
                case 1:
                    Instantiate(ammoBox, transform.position, Quaternion.identity);
                    break;
                case 2:
                    break;
                case 3:
                    break;

                default:
                    Debug.Log("error Random");
                    break;
            }
            Map1.UpdateKill();
            Destroy(gameObject);
            if (OnEnemyKilled != null)
            {
                OnEnemyKilled();
            }
        }

        private void Update()
        {
            if (health <= 0f)
                Die();
        }
    }
}