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

     void Start()
    {
        inventory_script = GameObject.Find("Inventory").GetComponent<Inventory>();
        health = GameObject.Find("FPSPlayer").GetComponent<PlayerHealth>();
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
                    break;    
            }
        }
        
       
    }

    
    void Update()
    {
        
    }
}
