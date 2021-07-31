using UnityEngine;

public class EnemyAttackController : MonoBehaviour
{
    public enum AttackType
    {
        ranged,
        melee
    }

    public Transform enemyTransform;
    public GameObject projectile;
    public int dmg = 0;
    public float attackRange;
    public float timeBetweenAttack;
    private bool targetInAttackRange;
    private bool alreadyAttacked;
    public AttackType attackType = AttackType.ranged;
    private Transform target;
    private float distanceToTarget;

    private void Awake()
    {
        //enemyTransform = gameObject.transform;
        target = GameObject.Find("Player").transform;
    }

    private void Update()
    {
        distanceToTarget = Vector3.Distance(enemyTransform.position, target.position);
        if (distanceToTarget < attackRange) Attacking();
    }

    private void Attacking()
    {
        enemyTransform.LookAt(target);
        if (!alreadyAttacked)
        {
            if (attackType == AttackType.ranged) RangedAttack();
            if (attackType == AttackType.melee) MeleeAttack();
            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttack);
        }
    }

    private void RangedAttack()
    {
        Rigidbody rb = Instantiate(projectile, enemyTransform.position, enemyTransform.rotation).GetComponent<Rigidbody>();
        Vector3 dir = target.position - enemyTransform.position;
        rb.GetComponent<EnemyProjectile>().SetDamage(dmg);
        rb.AddForce(dir.normalized * 32f, ForceMode.Impulse);
        rb.AddForce(enemyTransform.up * distanceToTarget / 5, ForceMode.Impulse);
    }

    private void MeleeAttack()
    {
        Animator anim = GetComponent<Animator>();
        anim.SetTrigger("AttackTrigger");
    }

    private void ResetAttack()
    {
        alreadyAttacked = false;
    }
}
