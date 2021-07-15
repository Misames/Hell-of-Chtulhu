using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerCutscene : MonoBehaviour
{

    public GameObject player;
    public GameObject CutsceneCam;

    private void Start()
    {
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
    }

}
