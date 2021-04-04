using UnityEngine;
using ECSModule;
/* Module avec info de position
 * 
 */
public class TemplateModule : Module
{
    //Données
    public Transform objectTr;
    
    //Constructeurs et Destructeurs
    public void Awake()
    {
        AddToAccessor<TemplateModule>();
    }

    public void OnDestroy()
    {
        RemoveFromAccessor<TemplateModule>();
    }

}
