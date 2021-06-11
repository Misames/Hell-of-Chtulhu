using System;
using System.Collections;
using System.Collections.Generic;
using Player;
using UnityEngine;

public class Select : MonoBehaviour
{
    private Inventory inventory_script;
    private GameObject player;
    private PlayerHealth health;
    private Weapon _weapons;

     void Start()
    {
        inventory_script = GameObject.Find("Inventory").GetComponent<Inventory>();
        health = GameObject.Find("Script").GetComponent<PlayerHealth>();
        _weapons = GameObject.Find("PrimaryWeapon").GetComponent<Weapon>();
    }

    public void Selection()
    {
        //numéro du slot

        int nrslot = transform.parent.GetSiblingIndex();

        if (inventory_script.slot[nrslot] > 0)
        {
            inventory_script.slot[nrslot] -= 1;
            inventory_script.updateTxt(nrslot,inventory_script.slot[nrslot].ToString());

            switch (nrslot)
            {
                case 0:
                    health.HealPlayer(30);
                    Debug.Log("heallllll");
                    break;   
                
                case 1:
                    health.HealPlayer(30);
                    break;
                
                case 2:
                    _weapons.bulletsLeft += 30;
                    break;
            }
        }
        
       
    }

    
    void Update()
    {
        
    }
}
