using System.Collections.Generic;
using UnityEngine;

namespace ECSModule
{
    
    
    /*Classe permettant de géré les updaters et de lancer leurs mis à jour
     */
    public class ECSController : MonoBehaviour
    {
        // Une liste de tout les updaters actifs
        private static List<IUpdater> _updaterList = new List<IUpdater>();

        // Pour le moment l'ajout est manuel dans le contructeur
        public ECSController()
        {
            new TemplateUpdater();
        }

        // Ajout d'un updater dans la liste
        public static void AddToUpdaterList(IUpdater updater)
        {
            if (!_updaterList.Contains(updater))
            {
                _updaterList.Add(updater);
            }
        }

        // Suppression d'un updater de la liste
        public static void RemoveFromUpdaterList(IUpdater updater)
        {
            if (_updaterList.Contains(updater))
            {
                _updaterList.Remove(updater);
            }
            else
            {
                Debug.LogError("Updater n'existe pas");
            }
        }

        // lance la mis à jour de tout les updaters
        private static void ActivateAllUpdaters()
        {
            foreach (var updater in _updaterList)
            {
                updater.UpdateModules();
            }
        }

        // On utilise le Update d'Unity pour lancer toute les majs
        private void Update()
        {
            ActivateAllUpdaters();
        }
    }
}