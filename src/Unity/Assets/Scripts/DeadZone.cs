using UnityEngine;

public class DeadZone : MonoBehaviour
{
    public GameManager gameManager;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player") gameManager.RestartGame();
    }
}
