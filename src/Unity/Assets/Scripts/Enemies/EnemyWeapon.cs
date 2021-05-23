using System;
using Player;
using UnityEngine;

public class EnemyWeapon : MonoBehaviour
{
    
    public float weaponDamage;
    public void SetDamage(float damage = 10)
    {
        weaponDamage = damage;
    }
    private void OnCollisionEnter(Collision collision)
    {
        var hit = collision.gameObject;
        var health = hit.GetComponent<PlayerHealth>();
        var test = hit.GetComponent<HealthBar>();
        if (health != null)
            health.TakeDamage(weaponDamage);
        Destroy(gameObject);
    }
}
