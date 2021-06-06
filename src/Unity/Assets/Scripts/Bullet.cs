using UnityEngine;
using Player;

public class Bullet : MonoBehaviour
{
    public float bulletDamage;

    public void SetDamage(float damage = 10)
    {
        bulletDamage = damage;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            var health = GameObject.Find("Script").GetComponent<PlayerHealth>();
            if (health != null) health.TakeDamage(bulletDamage);
            Destroy(gameObject);
        }
    }
}
