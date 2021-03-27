using UnityEngine;

public class DeadZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider col)
    {
        if (col.name == "Enemy")
        {
            print("ca marche");
            Destroy(gameObject);
        }
    }
}
