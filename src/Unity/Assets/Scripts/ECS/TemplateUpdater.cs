using System.Collections.Generic;
using UnityEngine;
using ECSModule;
/* Updater test avec déplacement vers la droite
 * 
 */
namespace ECSModule
{
    public class TemplateUpdater : IUpdater
    {
        // Déplacement vers la droite de tout les modules
        public override void UpdateModules()
        {
            Accessor<TemplateModule> singletonAccessor = Accessor<TemplateModule>.Instance();
            //Accessor<OtherTemplateModule> singletonOtherAccessor = Accessor<OtherTemplateModule>.Instance();

            foreach (var dictEntry in singletonAccessor.GetAllModules())
            {
                TemplateModule mod = dictEntry.Value;
                //OtherTemplateModule otherModule = singletonOtherAccessor.TryGetModule(dictEntry.Key);

                //Operations sur module
                mod.objectTr.position = new Vector2(mod.objectTr.position.x + 0.01f, mod.objectTr.position.y);

                /*                       
                 module.data1 = something;
                 if(otherModule.data1==x)  do something;

                 */

            }

        }
    }

}
