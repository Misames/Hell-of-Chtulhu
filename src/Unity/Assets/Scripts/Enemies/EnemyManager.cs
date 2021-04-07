using UnityEngine;

namespace Enemies
{
    public class EnemyManager : MonoBehaviour
    {
        public Transform[] m_SpawnPoints;
        public GameObject m_EnemyPrefab;
        void Start()
        {
            SpawnNewEnemy();
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
    }
}
