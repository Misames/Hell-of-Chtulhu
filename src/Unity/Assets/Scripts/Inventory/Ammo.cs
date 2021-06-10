using Player;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    
    private Inventory inventory_script;
    
    
    void Start()
    {
        inventory_script = GameObject.Find("Inventory").GetComponent<Inventory>();
    }

    

    private void OnTriggerEnter(Collider col)
    {

        if (col.gameObject.CompareTag("Player"))
        {
            inventory_script.slot[2] += 1;
            inventory_script.updateTxt(2, inventory_script.slot[2].ToString());
            Destroy(gameObject);   
        }
        
    }
}
