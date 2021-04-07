using UnityEngine;
using TMPro;
using Enemies;

namespace Player
{
    public class Weapon : MonoBehaviour
    {
        public int fireRate = 5;
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

        public int weaponSelected = 0;
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
            else if (Input.GetKeyDown(KeyCode.R)) Reload();
        }

        private void Shoot()
        {
            if (Physics.Raycast(Cam.transform.position, Cam.transform.forward, out var hit, RANGE))
            {
                var target = hit.transform.GetComponent<Enemy>();
                if (target != null)
                {
                    target.TakeDamage(damage);
                    // Afficher un marrquer de hit
                }
            }
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