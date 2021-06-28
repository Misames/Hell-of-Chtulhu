using UnityEngine;
using Player;
public class HealPickup : MonoBehaviour
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
            inventory_script.slot[0] += 1;
            inventory_script.updateTxt(0, inventory_script.slot[0].ToString());
            Destroy(gameObject);
        }
    }
}
