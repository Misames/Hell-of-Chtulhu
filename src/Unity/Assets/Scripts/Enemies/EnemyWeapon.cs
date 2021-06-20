using System;
using UnityEngine;
using Player;

public class EnemyWeapon : MonoBehaviour
{
    
    public float weaponDamage;
    
    public void SetDamage(float damage = 10)
    {
        weaponDamage = damage;
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject);
        if (other.gameObject.tag == "Player")
        {
            var health = GameObject.Find("Script").GetComponent<PlayerHealth>();
            if (health != null) health.TakeDamage(weaponDamage);
            
        }
    }
}
