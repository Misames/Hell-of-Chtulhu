using UnityEngine;

namespace Player
{
    public class bullet : MonoBehaviour
    {
        private void OnCollisionEnter(Collision collision)
        {
            var hit = collision.gameObject;
            var health = hit.GetComponent<PlayerHealth>();
            if (health != null)
            {
                health.TakeDamage(20);
            }

            Destroy(gameObject);
        }
    }
}

