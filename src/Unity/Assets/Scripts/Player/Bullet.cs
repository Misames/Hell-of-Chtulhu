using UnityEngine;

namespace Player
{
    public class Bullet : MonoBehaviour
    {
        public float bulletDamage;
        public void SetDamage(float damage = 10)
        {
            bulletDamage = damage;
        }
        private void OnCollisionEnter(Collision collision)
        {
            var hit = collision.gameObject;
            var health = hit.GetComponent<PlayerHealth>();
            var test = hit.GetComponent<HealthBar>();
            if (health != null)
                health.TakeDamage(bulletDamage);
            Destroy(gameObject);
        }
    }
}

