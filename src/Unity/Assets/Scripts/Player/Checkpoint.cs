using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerPrefs.SetFloat("x", gameObject.transform.position.x);
            PlayerPrefs.SetFloat("y", gameObject.transform.position.y);
            PlayerPrefs.SetFloat("z", gameObject.transform.position.z);
        }
    }
}
