using Player;
using UnityEngine;

public class ammoPickup : MonoBehaviour
{
    private int ammo = 30;
    private GameObject player;
    private Weapon _weapons;
    private bool _showGUI = false;

    // Start is called before the first frame update
    void Start()
    {
        _weapons = GameObject.Find("PrimaryWeapon").GetComponent<Weapon>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_showGUI == true)
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

        if (col.gameObject.CompareTag("Player"))
            _showGUI = true;
    }

    private void OnTriggerExit(Collider col)
    {
        if (col.gameObject.CompareTag("Player"))
            _showGUI = false;
    }

    private void OnGUI()
    {
        if (_showGUI == true)
            GUI.Box(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 12, 200, 25), " press E to pick Ammo");
    }
}
