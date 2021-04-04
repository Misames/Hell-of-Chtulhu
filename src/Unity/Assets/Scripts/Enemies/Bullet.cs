using System;
using System.Collections;
using System.Collections.Generic;
using Player;
using UnityEngine;

public class Bullet : MonoBehaviour
{
   private void OnCollisionEnter(Collision col)
   {
      var hit = col.gameObject;
      var health = hit.GetComponent<PlayerHealth>();
      if (health != null)
      {
         health.TakeDamage(20);
      }
      Destroy(gameObject);
   }
}
