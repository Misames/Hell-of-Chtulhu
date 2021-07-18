using System;
using System.Collections;
using System.Collections.Generic;
using EnemyScript;
using UnityEngine;

public class TriggerCutscene : MonoBehaviour
{
    public GameObject player;
    public GameObject CutsceneCam;
    public GameObject[] ennemis;
    public GameObject boss;
    
    private void Start()
    {
        boss.GetComponent<EnemyMovementController>().enabled = false;
        for (int i = 0; i < ennemis.Length; i++)
        {
            ennemis[i].GetComponent<EnemyMovementController>().enabled = false;
        }
        CutsceneCam.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            this.gameObject.GetComponent<BoxCollider>().enabled = false;
            CutsceneCam.SetActive(true);
            player.SetActive(false);
            StartCoroutine(FinCutscene());
        }
    }

    IEnumerator FinCutscene()
    {
        yield return new WaitForSeconds(4);
        player.SetActive(true);
        CutsceneCam.SetActive(false);
        for (int i = 0; i < ennemis.Length; i++)
        {
            ennemis[i].GetComponent<EnemyMovementController>().enabled = true;
        }
        boss.GetComponent<EnemyMovementController>().enabled = true;
    }
}
