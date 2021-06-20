using UnityEngine;

public class Test : MonoBehaviour
{
    public GameObject enemyManager;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player") enemyManager.SetActive(true);
    }

}
