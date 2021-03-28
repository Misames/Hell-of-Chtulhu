using UnityEngine;
using UnityEngine.AI;

namespace EnemyScript
{
    public class EnemyMovementController : MonoBehaviour
    {

        public NavMeshAgent agent;
        public Transform enemyTransform;
        private Transform _target;
        private Vector3 _walkPoint;
        public float maxPatrolRange;
        private bool _walkPointIsSet;
        private bool _canMove;
        public float sightRange;
        private bool _targetIsInSight;

        private void Awake()
        {
            _target = GameObject.Find("FPSPlayer").transform;
            _walkPointIsSet = false;
            _canMove = true;
        }

        public void SetCanMove(bool b)
        {
            _canMove = b;
        }

        void Update()
        {
            _targetIsInSight = Physics.CheckSphere(enemyTransform.position, sightRange, 1 << 9);
            //Debug.Log("in sight"+_targetIsInSight);

            if (!_targetIsInSight && _canMove)
            {
                //Debug.Log("patrol");
                Patrolling();
            }

            if (_targetIsInSight && _canMove)
            {
                //Debug.Log("chase");
                ChaseTarget();
            }
        }

        private void Patrolling()
        {
            if (!_walkPointIsSet) SearchWalkPoint();
            if (_walkPointIsSet) agent.SetDestination(_walkPoint);

            Vector3 distanceToWalkPoint = enemyTransform.position - _walkPoint;

            if (distanceToWalkPoint.magnitude < 1)
                _walkPointIsSet = false;
        }

        private void SearchWalkPoint()
        {
            //Debug.Log("searchWalk");
            for (var i = 0; i < 100; i++)
            {
                float randomZ = Random.Range(-maxPatrolRange, maxPatrolRange);
                float randomX = Random.Range(-maxPatrolRange, maxPatrolRange);
                if (!NavMesh.SamplePosition(new Vector3(enemyTransform.position.x + randomX, enemyTransform.position.y, enemyTransform.position.z + randomZ), out NavMeshHit hit, 2,
                    NavMesh.AllAreas)) continue;
                _walkPoint = hit.position;
                _walkPointIsSet = true;
                break;
            }
        }

        private void ChaseTarget()
        {
            agent.SetDestination(_target.position);
        }
    }
}
