﻿using Player;
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
        var health = collision.gameObject.GetComponent<PlayerHealth>();
        if (health != null) health.TakeDamage(weaponDamage);
        Destroy(gameObject);
    }
}
