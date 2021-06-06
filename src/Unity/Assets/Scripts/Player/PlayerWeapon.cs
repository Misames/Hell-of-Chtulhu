using System.Collections;
using System.Collections.Generic;
using Enemies;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
    
    public float weaponDamage;
    public void SetDamage(float damage = 10)
    {
        weaponDamage = damage;
    }
    private void OnCollisionEnter(Collision collision)
    {
        var hit = collision.gameObject;
        var health = hit.GetComponent<Enemy>();
        Debug.Log(hit);
        if (health != null)
            health.TakeDamage(weaponDamage);
        Destroy(gameObject);
    }
}