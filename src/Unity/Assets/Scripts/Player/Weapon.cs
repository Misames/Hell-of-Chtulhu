using UnityEngine;
using TMPro;
using Enemies;

namespace Player
{
    public class Weapon : MonoBehaviour
    {
        public int fireRate = 1;
        public float damage = 33;
        public int bulletsLeft = 200;
        public int bulletsPerMag = 30;
        public int currentBullets = 30;
        private int bulletsConsum = 0;
        public float reloadTime = 5.0f;
        private float nextTimeToFire = 0f;
        private const float RANGE = 200.0f;
        public Camera Cam;
        public TextMeshProUGUI BulletsTxt;

        private void Start()
        {
            Cursor.visible = false;
            BulletsTxt.text = $"{currentBullets} / {bulletsLeft}";
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
            if (Physics.Raycast(Cam.transform.position, Cam.transform.forward, out var hit, RANGE))
            {
                // Debug.Log($"Obj hit : {hit.transform.name}");
                var target = hit.transform.GetComponent<Enemy>();
                if (target != null)
                    target.TakeDamage(damage);
            }
            --currentBullets;
            ++bulletsConsum;
            BulletsTxt.text = $"{currentBullets} / {bulletsLeft}";
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
            BulletsTxt.text = $"{currentBullets} / {bulletsLeft}";
        }
    }
}