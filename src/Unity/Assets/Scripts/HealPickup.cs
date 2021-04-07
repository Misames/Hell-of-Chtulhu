using UnityEngine;

namespace Player
{
    public class HealPickup : MonoBehaviour
    {

        private int heal = 30;
        private GameObject player;
        private PlayerHealth health;
        private HealthBar bar;
        private bool ShowGUI = false;

        // Start is called before the first frame update
        void Start()
        {
            health = GameObject.Find("FPSPlayer").GetComponent<PlayerHealth>();
        }

        // Update is called once per frame
        void Update()
        {
            if (ShowGUI == true)
            {
                if (Input.GetKeyDown("e") && health.currentHealth < health.MAXHEALTH)
                {
                    health.currentHealth += heal;
                    if (health.currentHealth > health.MAXHEALTH)
                        health.currentHealth = health.MAXHEALTH;
                    Destroy(gameObject);
                }
            }
        }

        private void OnTriggerEnter(Collider col)
        {
            if (col.gameObject.tag == "Player")
                ShowGUI = true;
        }

        private void OnTriggerExit(Collider col)
        {
            if (col.gameObject.tag == "Player")
                ShowGUI = false;
        }

        private void OnGUI()
        {
            if (ShowGUI == true)
                GUI.Box(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 12, 200, 25), " press E to pick Heal");
        }
    }
}
