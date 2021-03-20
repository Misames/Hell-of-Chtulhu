using System.Linq;
using UnityEngine;

namespace Player
{
    public class PlayerHealth : MonoBehaviour
    {
        public float maxHealth = 100f;
        public float currentHealth;
        public Transform playerTransform;
        public Transform[] toBeCleanedTransforms;
        private Vector3 initialPlayerPosition;
        private Vector3[] initialToBeCleanedPositions;

        private void Start()
        {
            currentHealth = maxHealth;
            initialPlayerPosition = playerTransform.position;
            initialToBeCleanedPositions = toBeCleanedTransforms.Select(tr => tr.position).ToArray();
        }
        public void TakeDamage(int damage)
        {
            currentHealth -= damage;
            if (!(currentHealth <= 0)) return;
            currentHealth = 0;
            Debug.Log("mort");
            restart();
        }

        private void restart()
        {
            playerTransform.position = initialPlayerPosition;
            for (var i = 0; i < toBeCleanedTransforms.Length; i++)
            {
                toBeCleanedTransforms[i].position = initialToBeCleanedPositions[i];
            }
            currentHealth = maxHealth;
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    
    }
}
