using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    private bool activation = false;
    private GameObject Panel;
    public GameObject Player;
    public int[] slot;

    private void Start()
    {
        GetComponent<Canvas>().enabled = false;
    }

    private void Awake()
    {
        Panel = transform.GetChild(0).gameObject;
        slot = new int[Panel.transform.childCount];
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Cursor.lockState = CursorLockMode.None;
            activation = !activation;
            if (!activation)
            {
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
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
