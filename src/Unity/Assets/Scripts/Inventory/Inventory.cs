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

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Cursor.lockState = CursorLockMode.None;
            activation = !activation;
            if (!activation)
            {
                Cursor.visible = false;
                Time.timeScale = 1f;
            }
            else
            {
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
