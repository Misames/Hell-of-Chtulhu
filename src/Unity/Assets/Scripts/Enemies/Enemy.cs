using UnityEngine;
using Random = UnityEngine.Random;

public class Enemy : MonoBehaviour
{
    public delegate void EnemyKilled();
    public static event EnemyKilled OnEnemyKilled;
    public float health = 100f;
    private PlayerHealth playerHealth;
    private Weapon weapon;
    public GameObject healBox;
    public GameObject ammoBox;
    public GameManager gameManager;

    private void Start()
    {
        if (gameObject.name == "Boss") gameManager.GetComponent<GameManager>();
    }

    public void TakeDamage(float amount)
    {
        health -= amount;
        if (health <= 0f) Die();
    }

    private void Die()
    {
        if (gameObject.name == "Boss")
        {
            PlayerPrefs.SetInt("load", 0);
            gameManager.GameWin();
            Destroy(gameObject);
        }
        else
        {
            Map.UpdateKill(1);
            EnemyManager.nbEnemiesSpawned--;
            switch (Random.Range(0, 2))
            {
                case 0:
                    Instantiate(healBox, transform.position, Quaternion.identity);
                    break;
                case 1:
                    Instantiate(ammoBox, transform.position, Quaternion.identity);
                    break;
            }
            Destroy(gameObject);
            if (OnEnemyKilled != null) OnEnemyKilled();
        }
    }
}