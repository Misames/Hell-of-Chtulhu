using UnityEngine;
using Player;
public class HealPickup : MonoBehaviour
{

    private int heal = 30;
    private bool ShowGUI = false;

    // Update is called once per frame
    void Update()
    {
        if (ShowGUI)
        {
            var health = GameObject.Find("Script").GetComponent<PlayerHealth>();
            if (Input.GetKeyDown(KeyCode.E) && health.currentHealth < health.MAXHEALTH)
            {
                health.currentHealth += heal;
                if (health.currentHealth > health.MAXHEALTH) health.currentHealth = health.MAXHEALTH;
                Destroy(gameObject);
            }
        }
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player") ShowGUI = true;
    }

    private void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Player") ShowGUI = false;
    }

    private void OnGUI()
    {
        if (ShowGUI) GUI.Box(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 12, 200, 25), "press E to pick Heal");
    }
}
