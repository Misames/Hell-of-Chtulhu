using UnityEngine;

public class Target : MonoBehaviour
{
    public delegate void EnemyKilled();
    public static event EnemyKilled OnEnemyKilled;
    public float health = 100f;
    public void takeDamage(float amount)
    {
        health -= amount;
        if (health <= 0f)
            Die();
    }
    private void Die()
    {
        Destroy(gameObject);
        if (OnEnemyKilled != null)
            OnEnemyKilled();
    }
}