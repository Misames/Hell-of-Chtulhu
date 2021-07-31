using UnityEngine;

public class Ammo : MonoBehaviour
{
    private Inventory inventory_script;

    private void Start()
    {
        inventory_script = GameObject.Find("Inventory").GetComponent<Inventory>();
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            inventory_script.slot[1] += 1;
            inventory_script.updateTxt(1, inventory_script.slot[1].ToString());
            Destroy(gameObject);
        }
    }
}
