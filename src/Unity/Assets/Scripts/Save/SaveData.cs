using System;
using System.IO;
using UnityEngine;

public class SaveData : MonoBehaviour
{
    public Inventory inventaire;
    public int Healtpack ;
    public int AmmoBox;
    public Transform player;
    public float x, y, z;
    
    private string separator = "SEPARATOR";

    

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            Healtpack = inventaire.slot[0];
            AmmoBox = inventaire.slot[2];
            x = player.position.x;
            y = player.position.y;
            z = player.position.z;
            Save();
            
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            Load();
            player.position.Set(x,y,z);
        }
        
    }

    void Save()
    {
        string[] content = new string[]
        {
            Healtpack.ToString(),
            AmmoBox.ToString(),
            x.ToString(),
            y.ToString(),
            z.ToString()
        };


        string saveString = string.Join(separator, content);
        File.WriteAllText(Application.dataPath + "/save.txt",saveString);
        Debug.Log("Sauvegarde effectué");
    }

    void Load()
    {
        string saveString = File.ReadAllText(Application.dataPath + "/save.txt");

        string[] content = saveString.Split(new[] {separator}, System.StringSplitOptions.None);

        Healtpack = int.Parse(content[0]);
        AmmoBox = int.Parse((content[1]));
        inventaire.slot[0] = Healtpack;
        inventaire.updateTxt(0,Healtpack.ToString());    
        inventaire.slot[2] = AmmoBox;
        inventaire.updateTxt(2,AmmoBox.ToString());
        x = float.Parse(content[2]);
        y = float.Parse(content[3]);
        z = float.Parse(content[4]);
       
        
        
        
        Debug.Log("Chargement efféctueé");
    }
}
