using UnityEngine;
using UnityEngine.AI;


namespace EnemyScript
{
    public class EnemyAttackController : MonoBehaviour
    {
        public NavMeshAgent agent;
        public Transform enemyTransform;
        private Transform _target;
        public GameObject projectile;
        private Vector3 _walkPoint;
        public int dmg = 0;
        public float attackRange;
        public float timeBetweenAttack;
        private bool _targetInAttackRange;
        private bool alreadyAttacked;

        private void Awake()
        {
            _target = GameObject.Find("FPSPlayer").transform;
        }

        void Update()
        {
            _targetInAttackRange = Physics.CheckSphere(enemyTransform.position, attackRange, 1 << 9);

            if (_targetInAttackRange)
            {
                Debug.Log("attack");
                Attacking();
            }
        }

        void Attacking()
        {
            agent.SetDestination(enemyTransform.position);
            enemyTransform.LookAt(_target);

            if (!alreadyAttacked)
            {
                Rigidbody rb = Instantiate(projectile, enemyTransform.position, enemyTransform.rotation).GetComponent<Rigidbody>();
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
