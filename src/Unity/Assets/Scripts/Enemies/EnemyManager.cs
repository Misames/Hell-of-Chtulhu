﻿using UnityEngine;
public class EnemyManager : MonoBehaviour
{
    public Transform[] m_SpawnPoints;
    public GameObject m_EnemyPrefab;
    // Start is called before the first frame update
    void Start()
    {
        SpawnNewEnemy();
    }
    void OnEnable()
    {
        Target.OnEnemyKilled += SpawnNewEnemy;
    }
    // Update is called once per frame
    void SpawnNewEnemy()
    {
        int randomSpawn = Mathf.RoundToInt((Random.Range(0f, m_SpawnPoints.Length - 1f)));
        Instantiate(m_EnemyPrefab, m_SpawnPoints[randomSpawn].transform.position, Quaternion.identity);
    }
}
