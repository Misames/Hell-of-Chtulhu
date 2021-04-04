using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Enemies
{
    public class EnemyManager : MonoBehaviour
    {
        
        public Transform[] m_SpawnPoints; //liste spawnPoint
        private GameObject[] currentEnnemis;
        public GameObject m_EnemyPrefab;

        public float delay;
        
        
        void Start()
        {
            //SpawnNewEnemy();
            InvokeRepeating("Spawning",0,delay);
        }

        

        void OnEnable()
        {
            Enemy.OnEnemyKilled += SpawnNewEnemy;
        }
        
        void SpawnNewEnemy()
        {
            int randomSpawn = Mathf.RoundToInt((Random.Range(0f, m_SpawnPoints.Length - 1f)));
            Instantiate(m_EnemyPrefab, m_SpawnPoints[randomSpawn].transform.position, Quaternion.identity);
        }
        
        
        void Spawning()
        {
            int randomNumber = Random.Range(0, m_SpawnPoints.Length);
            var randomTransform = m_SpawnPoints[randomNumber];

            Instantiate(m_EnemyPrefab, randomTransform.transform.position, Quaternion.identity);
        }
    }

    
    
    
}
