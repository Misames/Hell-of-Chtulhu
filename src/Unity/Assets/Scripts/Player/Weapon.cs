﻿using System;
using UnityEngine;
using TMPro;
using Enemies;

namespace Player
{
    public class Weapon : MonoBehaviour
    {
        public int fireRate = 1;
        public float damage = 100;
        public int bulletsLeft = 200;
        public int bulletsPerMag = 30;
        public int currentBullets = 30;
        
        private int bulletsConsum = 0;
        public float reloadTime = 5.0f;
        private float nextTimeToFire = 0f;
        private const float RANGE = 200.0f;
        
        public Camera Cam;
        public TextMeshProUGUI BulletsTxt;
        public ParticleSystem ShootParticle;

        private RaycastHit[] hits;

        public GameObject gun;
        private void Start()
        {
            
            Cursor.visible = false;
        }

        private void Update()
        {
            if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire)
            {
                if (currentBullets > 0)
                {
                    nextTimeToFire = Time.time + 1f / fireRate;
                    Shoot();
                }
            }
            else if (Input.GetKeyDown(KeyCode.R)) Reload();
            BulletsTxt.text = $"{currentBullets} / {bulletsLeft}";
        }

        private void Shoot()
        {
            
            ShootParticle.Play();
            hits = null;
            hits = Physics.RaycastAll(this.transform.position, Cam.transform.forward, 100.0F);
            
            foreach (var hit in hits)
            {
                Debug.Log(hit.collider.gameObject);
                if (hit.transform.CompareTag("Enemy"))
                { 
                    
                    Debug.Log("found");
                    var target = hit.transform.GetComponent<Enemy>();
                    target.TakeDamage(damage);
                }
            }
            --currentBullets;
            ++bulletsConsum;
            UpdateBullets();
            
        }
        
        void OnDrawGizmos()
        {
            // Draws a 5 unit long red line in front of the object
            Gizmos.color = Color.red;
            Vector3 direction = Cam.transform.forward * 500;
            Gizmos.DrawRay(this.transform.position, direction);
        }

        private void Reload()
        {
            if (bulletsLeft >= bulletsPerMag)
            {
                bulletsLeft -= bulletsConsum;
                currentBullets = bulletsPerMag;
            }
            else
            {
                if (bulletsConsum > bulletsLeft)
                {
                    currentBullets += bulletsLeft;
                    bulletsLeft = 0;
                }
                else
                {
                    currentBullets += bulletsConsum;
                    bulletsLeft -= bulletsConsum;
                }
            }
            bulletsConsum = 0;
        }

        private void SelectWeapon()
        {
            int i = 0;
            foreach (Transform weapon in transform)
            {
                if (i == weaponSelected) weapon.gameObject.SetActive(true);
                else weapon.gameObject.SetActive(false);
                ++i;
            }
        }
    }
}