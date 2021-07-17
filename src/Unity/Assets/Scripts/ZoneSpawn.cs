﻿using UnityEngine;

public class ZoneSpawn : MonoBehaviour
{
    public bool zoneClear = false;
    public GameObject enemyManager;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player") enemyManager.SetActive(true);
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player") enemyManager.SetActive(false);
    }

}
