﻿using UnityEngine;

public class EnemyWeapon : MonoBehaviour
{
    public float weaponDamage;

    public void SetDamage(float damage = 10)
    {
        weaponDamage = damage;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            var health = GameObject.Find("Script").GetComponent<PlayerHealth>();
            if (health != null) health.TakeDamage(weaponDamage);
        }
    }
}
