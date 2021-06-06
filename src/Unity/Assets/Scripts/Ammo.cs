using Player;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    private int ammo = 30;
    private bool showGUI = false;

    void Update()
    {
        if (showGUI)
        {
            var weapon = GameObject.Find("PrimaryWeapon").GetComponent<Weapon>();
            if (Input.GetKeyDown(KeyCode.E))
            {
                weapon.bulletsLeft += ammo;
                Destroy(gameObject);
            }
        }
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player") showGUI = true;
    }

    private void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Player") showGUI = false;
    }

    private void OnGUI()
    {
        if (showGUI) GUI.Box(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 12, 200, 25), "press E to pick Ammo");
    }
}
