using System.Linq;
using UnityEngine;
public class PlayerHealth : MonoBehaviour
{
    public float maxhealth = 100f;
    public float currentHealth;
    public Transform playerTransform;
    public Transform[] toBeCleanedTransforms;
    private Vector3 initialPlayerPosition;
    private Vector3[] initialToBeCleanedPositions;
    
    void Start()
    {
        currentHealth = maxhealth;
        initialPlayerPosition = playerTransform.position;
        initialToBeCleanedPositions = toBeCleanedTransforms.Select(tr => tr.position).ToArray();
    }
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            Debug.Log("mort");
            restart();
        }
    }

    public void restart()
    {
        playerTransform.position = initialPlayerPosition;
        for (var i = 0; i < toBeCleanedTransforms.Length; i++)
        {
            toBeCleanedTransforms[i].position = initialToBeCleanedPositions[i];
        }
        currentHealth = maxhealth;
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    
}
