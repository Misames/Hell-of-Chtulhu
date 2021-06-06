using UnityEngine;
using UnityEngine.SceneManagement;
public class DeadZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player") SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
