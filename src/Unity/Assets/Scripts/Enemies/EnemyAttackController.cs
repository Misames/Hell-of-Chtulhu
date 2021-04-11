using Player;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public enum AttackType
{
    Ranged,
    Melee
}
namespace EnemyScript
{
    public class EnemyAttackController : MonoBehaviour
    {
        public AttackType attackType;
        public Transform enemyTransform;
        public GameObject attackSource;
        public GameObject projectile;
        
        public int dmg = 0;
        public float attackRange;
        public float timeBetweenAttack;
        
        public UnityEvent attackEvent;
        
        private bool targetInAttackRange;
        private bool alreadyAttacked;
        private Transform target;
        private float distanceToTarget;

        private void Awake()
        {
            target = GameObject.Find("FPSPlayer").transform;
        }

        void Update()
        {
            distanceToTarget = Vector3.Distance(enemyTransform.position, target.position);
            if (distanceToTarget < attackRange)
            {
                //Debug.Log("attack");
                Attacking();
            }
        }

        void Attacking()
        {
            if (!alreadyAttacked)
            {
                if(attackType==AttackType.Melee) MeleeAttack();
                else if(attackType==AttackType.Ranged) RangedAttack();
                alreadyAttacked = true;
                Invoke(nameof(ResetAttack), timeBetweenAttack);
            }
        }

        void RangedAttack()
        {
            attackSource.transform.LookAt(target);
            Rigidbody rb = Instantiate(projectile, attackSource.transform.position, attackSource.transform.rotation).GetComponent<Rigidbody>();
            rb.GetComponent<EnemyWeapon>().SetDamage(dmg);

            rb.AddForce(attackSource.transform.forward * 32f, ForceMode.Impulse);
            rb.AddForce(attackSource.transform.up * 8f, ForceMode.Impulse);
            
        }
        
        void MeleeAttack()
        {
            attackSource.GetComponent<EnemyWeapon>().SetDamage(dmg);
            attackEvent.Invoke();
        }
        
        void ResetAttack()
        {
            alreadyAttacked = false;
        }
    }
}
