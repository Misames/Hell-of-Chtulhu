using System.Collections;
using UnityEngine;

public class TriggerCutscene : MonoBehaviour
{
    public GameObject player;
    public GameObject CutsceneCam;
    public GameObject[] ennemis;
    public GameObject boss;
    public GameObject ui;

    private void Start()
    {
        boss.GetComponent<EnemyMovementController>().enabled = false;
        for (int i = 0; i < ennemis.Length; i++) ennemis[i].GetComponent<EnemyMovementController>().enabled = false;
        CutsceneCam.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ui.SetActive(true);
            this.gameObject.GetComponent<BoxCollider>().enabled = false;
            CutsceneCam.SetActive(true);
            player.SetActive(false);
            StartCoroutine(FinCutscene());
        }
    }

    private IEnumerator FinCutscene()
    {
        yield return new WaitForSeconds(7);
        player.SetActive(true);
        CutsceneCam.SetActive(false);
        for (int i = 0; i < ennemis.Length; i++) ennemis[i].GetComponent<EnemyMovementController>().enabled = true;
        boss.GetComponent<EnemyMovementController>().enabled = true;
        ui.SetActive(false);
    }
}
