using System;
using Player;
using UnityEngine;

public class Select : MonoBehaviour
{
    private Inventory inventory_script;
    private GameObject player;
    private PlayerHealth health;
    public Weapon weapon;
    public Weapon weapon2;
    public WeaponSwitching selected_weapon;
    private int num_weapon;

    void Start()
    {
        inventory_script = GameObject.Find("Inventory").GetComponent<Inventory>();
        health = GameObject.Find("Script").GetComponent<PlayerHealth>();
    }

    private void Update()
    {
        num_weapon = selected_weapon.weaponSelected;
    }

    public void Selection()
    {
        // numéro du slot
        int nrslot = transform.parent.GetSiblingIndex();
        if (inventory_script.slot[nrslot] > 0)
        {
            inventory_script.slot[nrslot] -= 1;
            inventory_script.updateTxt(nrslot, inventory_script.slot[nrslot].ToString());
            switch (nrslot)
            {
                case 0:
                    health.HealPlayer(30);
                    break;
                case 1:
                    if (num_weapon == 0)
                    {
                        weapon.bulletsLeft += 30;
                    }
                    else
                    {
                        weapon2.bulletsLeft += 10;
                    }
                    break;
            }
        }
    }
}
