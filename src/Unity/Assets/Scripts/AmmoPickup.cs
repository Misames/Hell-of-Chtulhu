using Player;
using UnityEngine;

public class ammoPickup : MonoBehaviour
{
    private int ammo = 30;
    private GameObject player;
    private Weapon _weapons;
    private bool _showGUI = false;

    void Start()
    {
        _weapons = GameObject.Find("PrimaryWeapon").GetComponent<Weapon>();
    }
    void Update()
    {
        if (_showGUI)
        {
            if (Input.GetKeyDown("e"))
            {
                _weapons.bulletsLeft += ammo;
                Destroy(gameObject);
            }
        }
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Player")) _showGUI = true;
    }

    private void OnTriggerExit(Collider col)
    {
        if (col.gameObject.CompareTag("Player")) _showGUI = false;
    }

    private void OnGUI()
    {
        if (_showGUI) GUI.Box(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 12, 200, 25), " press E to pick Ammo");
    }
}
