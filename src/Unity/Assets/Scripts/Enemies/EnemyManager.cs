using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public Transform[] m_SpawnPoints;
    public GameObject m_EnemyPrefabRanged;
    public GameObject m_EnemyPrefabMelee;
    public static int currentMaxEnemies = 10;
    public static int enemiesLeftToSpawn = 25;
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
        int randomEnnemy = Random.Range(0, 2);
        switch (randomEnnemy)
        {
            case 0:
                Instantiate(m_EnemyPrefabRanged, m_SpawnPoints[randomSpawn].transform.position, Quaternion.identity);
                break;
            case 1:
                Instantiate(m_EnemyPrefabMelee, m_SpawnPoints[randomSpawn].transform.position, Quaternion.identity);
                break;
            default:
                break;
        }

    }
}