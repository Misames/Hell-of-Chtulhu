using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using UnityEngine;

public class Inventory : MonoBehaviour
{

    bool InventoryONOFF = false;
    public GameObject Player;
    private GameObject Panel;
    public int[] Slot;
    private Inventory Inventaire_Script;
    public GameObject pauseMenu;
    void Start()
    {
        //GetComponent<Canvas>().enabled = false;
        Panel = transform.GetChild(0).gameObject;
        Slot = new int[Panel.transform.childCount];

        Inventaire_Script = GameObject.Find("Inventory").GetComponent<Inventory>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("i"))
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        GetComponent<Canvas>().enabled = InventoryONOFF;
    }

    void selection()
    {
        int numSlot = transform.parent.GetSiblingIndex();
        Inventaire_Script.Slot[numSlot] -= 1;
    }

}
