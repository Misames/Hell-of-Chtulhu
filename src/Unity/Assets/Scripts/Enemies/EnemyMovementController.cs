using UnityEngine;
using UnityEngine.AI;

namespace EnemyScript
{
    enum Status
    {
        chase,
        alert,
        patrol
    }
    
    public class EnemyMovementController : MonoBehaviour
    {

        public NavMeshAgent agent;
        public Transform enemyTransform;
        private Transform target;
        private Vector3 walkPoint;
        private Status enemyStatus;
        public float maxPatrolRange;
        private bool walkPointIsSet;
        private bool canMove;
        public float sightRange;
        private bool targetIsInSight;

        private void Awake()
        {
            target = GameObject.Find("FPSPlayer").transform;
            walkPointIsSet = false;
            canMove = true;
            enemyStatus = Status.patrol;

        }

        public void SetCanMove(bool b)
        {
            canMove = b;
        }

        void Update()
        {
            targetIsInSight = Vector3.Distance(enemyTransform.position,target.position)< sightRange;
            //Debug.Log("distance: "+Vector3.Distance(enemyTransform.position,target.position));

            if (!targetIsInSight)
            {
                enemyStatus = Status.patrol;
                Patrolling();
            }
            if (targetIsInSight )
            {
                enemyStatus = Status.chase;
                ChaseTarget();
            }
        }

        private void Patrolling()
        {
            
            if (!walkPointIsSet)
            {
                Debug.Log("newpoint");
                SearchWalkPoint();
                agent.SetDestination(walkPoint);
            }
            
            if (Vector3.Distance(enemyTransform.position,walkPoint)<1)
                walkPointIsSet = false;
        }

        private void SearchWalkPoint()
        {
            if (NavMesh.SamplePosition(enemyTransform.position, out NavMeshHit hit, maxPatrolRange, NavMesh.AllAreas))
            {
                walkPoint = hit.position;
                walkPointIsSet = true;
            };
        }
        
        private void ChaseTarget()
        {
            
            agent.SetDestination(target.position);
        }
    }
}
