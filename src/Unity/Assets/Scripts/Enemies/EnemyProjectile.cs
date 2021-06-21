using UnityEngine;
using Player;

public class EnemyProjectile : MonoBehaviour
{
    public float weaponDamage;

    public void SetDamage(float damage = 10)
    {
        weaponDamage = damage;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            var health = GameObject.Find("Script").GetComponent<PlayerHealth>();
            if (health != null) health.TakeDamage(weaponDamage);
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "Ground") Destroy(gameObject);
    }
}