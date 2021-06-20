using UnityEngine;

public class ZoneSpawn : MonoBehaviour
{
    public GameObject enemyManager;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player") enemyManager.SetActive(true);
    }

}
