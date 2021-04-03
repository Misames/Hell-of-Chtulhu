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
            if (!InventoryONOFF)
                ResumeGame();
            else
                PauseGame();
        }
        
                    
            
            GetComponent<Canvas>().enabled = InventoryONOFF;
            
        }

         

    
    
    void selection()
    {
        int numSlot = transform.parent.GetSiblingIndex();
        Inventaire_Script.Slot[numSlot] -= 1;
    }
    
    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        InventoryONOFF = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    
    public void PauseGame()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        pauseMenu.SetActive(true);
        
    }
}
