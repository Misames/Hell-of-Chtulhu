using System;
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
        
        public GameObject attackSource;
        public GameObject projectile;
        
        public Camera Cam;
        public TextMeshProUGUI BulletsTxt;
        public ParticleSystem ShootParticle;

        private RaycastHit[] hits;

        public GameObject gun;
        private void Start()
        {
            
            Cursor.visible = false;
            UpdateBullets();
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
            else if (Input.GetKeyDown(KeyCode.R))
                Reload();
        }

        private void Shoot()
        {
            
            ShootParticle.Play();
            
            Rigidbody rb = Instantiate(projectile, attackSource.transform.position, attackSource.transform.rotation).GetComponent<Rigidbody>();
            rb.GetComponent<PlayerProjectile>().SetDamage(damage);

            rb.AddForce(attackSource.transform.forward * 64f, ForceMode.Impulse);
            --currentBullets;
            ++bulletsConsum;
            
            /*
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
            */
            --currentBullets;
            ++bulletsConsum;
            UpdateBullets();
            
            
            
            
            
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
            UpdateBullets();
        }

        private void UpdateBullets()
        {
            BulletsTxt.text = $"{currentBullets} / {bulletsLeft}";
        }
    }
}