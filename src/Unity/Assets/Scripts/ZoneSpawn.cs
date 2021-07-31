using UnityEngine;

public class ZoneSpawn : MonoBehaviour
{
    public bool zoneClear = false;
    public GameObject enemyManager;
    public int zoneNumber;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player") enemyManager.SetActive(true);
        Map.ChangeCurrentZone(zoneNumber);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player") enemyManager.SetActive(false);
        Map.ChangeCurrentZone(0);
    }
}
