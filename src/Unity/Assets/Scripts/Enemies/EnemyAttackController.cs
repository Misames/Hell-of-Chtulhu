using Player;
using UnityEngine;
using UnityEngine.AI;


namespace EnemyScript
{
    public class EnemyAttackController : MonoBehaviour
    {
        public Transform enemyTransform;
        public GameObject projectile;

        public int dmg = 0;
        public float attackRange;
        public float timeBetweenAttack;
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
            
            if (distanceToTarget<attackRange)
            {
                //Debug.Log("attack");
                Attacking();
            }
        }

        void Attacking()
        {
            
            enemyTransform.LookAt(target);

            if (!alreadyAttacked)
            {
                Rigidbody rb = Instantiate(projectile, enemyTransform.position, enemyTransform.rotation).GetComponent<Rigidbody>();
                rb.GetComponent<Bullet>().SetDamage(dmg);
                
                rb.AddForce(enemyTransform.forward * 32f, ForceMode.Impulse);
                rb.AddForce(enemyTransform.up * 8f, ForceMode.Impulse);
                alreadyAttacked = true;
                Invoke(nameof(ResetAttack), timeBetweenAttack);
            }
        }

        void ResetAttack()
        {
            alreadyAttacked = false;
        }
    }
}
