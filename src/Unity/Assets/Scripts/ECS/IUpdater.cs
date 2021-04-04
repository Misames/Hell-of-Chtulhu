namespace ECSModule
{
    /*Classe permettant de mettre a jour les modules en les accedant depuis des Accessor 
     * classe à implémenter avec une fonction d'update
     */
    public abstract class IUpdater
    {
        // Ajout de l'updater à la liste dans ECS
        public IUpdater()
        {
            ECSController.AddToUpdaterList(this);
        }

        //Fonction à implémenter qui va update les modules rencontrés
        public abstract void UpdateModules();
    }
}
