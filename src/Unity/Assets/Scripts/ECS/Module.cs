using UnityEngine;

namespace ECSModule
{
    /* Classe module contenant des informations sur l'objet dont il est l'instance
     * classe à implémenter avec des attributs
     */
    public abstract class Module : MonoBehaviour
    {
        // Ajoute l'ID et le module à l'Accessor correspondant
        public void AddToAccessor<T>() where T : class
        {
            Accessor<T> singletonAccessor = Accessor<T>.Instance();
            singletonAccessor.AddReferenceToAccessor(transform.gameObject.GetInstanceID(), this as T);
        }

        // Enlève le module à l'Accessor correspondant
        public void RemoveFromAccessor<T>() where T : class
        {
            Accessor<T> singletonAccessor = Accessor<T>.Instance();
            singletonAccessor.RemoveReferenceFromAccessor(transform.gameObject.GetInstanceID());
        }

    }
}
