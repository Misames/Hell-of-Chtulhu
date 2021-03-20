using UnityEngine;
using TMPro;
using Enemies;

namespace Player
{
    public class PlayerWeapon : MonoBehaviour
    {
        public int health;
        public int fireRate = 5;
        public float damage;
        public int ammo;
        public int totalAmmo;
        public int maxAmmo;
        public float reloadTime = 2f;
        public TextMeshProUGUI AmmoUI;
        public Camera FpsCam;
        private float nextTimeToFire = 0f;
        private const float Range = 100f;

        private void Start()
        {
            Cursor.visible = false;
            AmmoUI.text = $"{ammo} / {totalAmmo}";
        }

        void Update()
        {
            if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire)
            {
                if (ammo > 0)
                {
                    nextTimeToFire = Time.time + 1f / fireRate;
                    Shoot();
                }
            }
            else if (Input.GetKeyDown(KeyCode.R))
            {
                ReloadWeapon();
            }
        }

        private void Shoot()
        {
            if (Physics.Raycast(FpsCam.transform.position, FpsCam.transform.forward, out var hit, Range))
            {
                var target = hit.transform.GetComponent<EnemiesTarget>();
                if (target != null)
                {
                    target.TakeDamage(damage);
                }
            }
            --ammo;
            AmmoUI.text = $"{ammo} / {totalAmmo}";
        }

        private void ReloadWeapon()
        {
            if (ammo != maxAmmo)
            {
                int deltaAmmo = maxAmmo - ammo;
                totalAmmo -= deltaAmmo;
                if (totalAmmo < 0)
                {
                    deltaAmmo += totalAmmo;
                    totalAmmo = 0;
                }

                ammo += deltaAmmo;
            }

            AmmoUI.text = $"{ammo} / {totalAmmo}";
        }
    }
}