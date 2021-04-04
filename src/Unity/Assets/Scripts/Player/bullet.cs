using UnityEngine;

namespace Player
{
    public class Bullet : MonoBehaviour
    {
        private float bulletDamage;
        public void SetDamage(float damage = 10)
        {
            bulletDamage = damage;
        }
        private void OnCollisionEnter(Collision collision)
        {
            //Debug.Log("collision with player");
            var hit = collision.gameObject;
            //Debug.Log(hit.gameObject.name);
            var health = hit.GetComponent<PlayerHealth>();
            //Debug.Log(health);
            if (health != null)
                health.TakeDamage(bulletDamage);
            Destroy(gameObject);
        }
    }
}

