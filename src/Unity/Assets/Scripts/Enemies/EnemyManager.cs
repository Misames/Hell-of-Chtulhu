using UnityEngine;

namespace Enemies
{
    public class EnemyManager : MonoBehaviour
    {
        public Transform[] m_SpawnPoints;
        public GameObject m_EnemyPrefab;
        public static int currentMaxEnemies = 20; //max d'ennemies durant la vague
        public static int enemiesLeftToSpawn = 40; // descend à chaque spawn
        public static int nbEnemiesSpawned = 0;

        private void Start()
        {
            for (int i = 0; i < currentMaxEnemies; i++)
            {
                SpawnNewEnemy();
            }
        }

        private void Update()
        {
            if (nbEnemiesSpawned < currentMaxEnemies && enemiesLeftToSpawn > 0) SpawnNewEnemy();
        }

        private void SpawnNewEnemy()
        {
            enemiesLeftToSpawn--;
            nbEnemiesSpawned++;
            int randomSpawn = Mathf.RoundToInt((Random.Range(0f, m_SpawnPoints.Length - 1f)));
            Instantiate(m_EnemyPrefab, m_SpawnPoints[randomSpawn].transform.position, Quaternion.identity);
        }
    }
}
