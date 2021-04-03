using System;
using System.Collections.Generic;

namespace ECSModule
{
/* Classe permettant de lister les instances des modules
 * et de garder en mémoire les ID de ces instances
 * Le typage des modules est dynamique grace aux générics
 */
    public class Accessor<T> where T : class
    {
        // Le singleton
        private static Accessor<T> _instance;

        // Une fonction initialisant et renvoyant le singleton
        public static Accessor<T> Instance()
        {
            if (_instance == null)
            {
                _instance = new Accessor<T>();
            }

            return _instance;
        }

        // Le module contenant les id et les modules correspondants
        private Dictionary<int, T> modulesAndID;

        // Constructeur initialisant le dictionnaire
        public Accessor()
        {
            modulesAndID = new Dictionary<int, T>();
        }

        // Ajoute le module et l'ID de son instance dans le dictionnaire
        public void AddReferenceToAccessor(int newInstanceId, T newModule)
        {
            modulesAndID.Add(newInstanceId, newModule);
        }

        // Enleve un module et son ID du dictionnaire
        public void RemoveReferenceFromAccessor(int instanceId)
        {
            modulesAndID.Remove(instanceId);
        }

        // Retourne le dictionnaire de module
        public Dictionary<int, T> GetAllModules()
        {
            return modulesAndID;
        }


        // Permet de récuperer un module à partir d'un ID
        public T TryGetModule(int instanceID)
        {
            T returnModule;
            modulesAndID.TryGetValue(instanceID, out returnModule);
            if (returnModule == null)
            { 
                Console.Error.WriteLine("Module n'existe pas");
            }

            return returnModule;

        }

    }
}