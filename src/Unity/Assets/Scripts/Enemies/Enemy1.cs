using System;
using Player;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

namespace Enemies
{
    public class Enemy1 : MonoBehaviour
    {
        public delegate void EnemyKilled();
        public static event EnemyKilled OnEnemyKilled;
        public float health = 100f;
        private PlayerHealth _PlayerHealth;
        private Weapon _weapon;
        public GameManager _gameManager;

        private void Start()
        {
            _gameManager.GetComponent<GameManager>();
        }

        public void TakeDamage(float amount)
        {
            health -= amount;
            if (health <= 0f) Die();
        }

        private void Die()
        {
            Map.UpdateKill(1);
            EnemyManager.nbEnemiesSpawned--;
            _gameManager.GameWin();
            Destroy(gameObject);
            if (OnEnemyKilled != null) OnEnemyKilled();
        }
    }
}