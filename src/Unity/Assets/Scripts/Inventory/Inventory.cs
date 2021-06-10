using System.Collections;
using System.Collections.Generic;
using Player;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    private bool activation = false;

    public GameObject Player;

    private GameObject Panel;
    public int[] slot;
    
    
    
    
    void Start()
    {
        GetComponent<Canvas>().enabled = false;
        Panel = transform.GetChild(0).gameObject;
        slot = new int[Panel.transform.childCount];
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            activation = !activation;

            if (!activation)
            {
                //Player.GetComponent<CharacterController>().enabled = true;
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = false;
                Time.timeScale = 1f;
            }
            else
            {
                //Player.GetComponent<CharacterController>().enabled = false;
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                Time.timeScale = 0f;
            }

            GetComponent<Canvas>().enabled = activation;
        }
    }
    
    public void updateTxt(int nrslot, string txt)
    {
        Panel.transform.GetChild(nrslot).GetChild(1).GetComponent<Text>().text = txt;
    }
    
}
