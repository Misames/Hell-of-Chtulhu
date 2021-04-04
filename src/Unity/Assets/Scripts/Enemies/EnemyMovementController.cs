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
        public float speed;
        public float maxPatrolRange;
        public float sightRange;
        public float closestDistance;

        private Transform target;
        private Vector3 walkPoint;
        private Status enemyStatus;
        private bool walkPointIsSet;
        private bool canMove;
        private float distanceToTarget;

        private void Awake()
        {
            target = GameObject.Find("FPSPlayer").transform;
            walkPointIsSet = false;
            canMove = true;
            enemyStatus = Status.patrol;
            agent.speed = speed;

        }

        public void SetCanMove(bool b)
        {
            canMove = b;
        }

        void Update()
        {
            distanceToTarget = Vector3.Distance(enemyTransform.position, target.position);
            //Debug.Log("distance: "+Vector3.Distance(enemyTransform.position,target.position));
            if (!(distanceToTarget < sightRange) && canMove)
            {
                enemyStatus = Status.patrol;
                Patrolling();
            }
            if ((distanceToTarget < sightRange) && canMove)
            {
                enemyStatus = Status.chase;
                ChaseTarget();
            }
        }

        private void Patrolling()
        {
            if (!walkPointIsSet)
            {
                //Debug.Log("newpoint");
                SearchWalkPoint();
                agent.SetDestination(walkPoint);
            }

            if (Vector3.Distance(enemyTransform.position, walkPoint) < 1)
            {
                //Debug.Log("reached");
                walkPointIsSet = false;
            }
        }

        private void SearchWalkPoint()
        {
            if (NavMesh.SamplePosition(new Vector3(enemyTransform.position.x + Random.Range(-maxPatrolRange, maxPatrolRange), enemyTransform.position.y, enemyTransform.position.z + Random.Range(-maxPatrolRange, maxPatrolRange)), out NavMeshHit hit, 100, NavMesh.AllAreas))
            {
                //Debug.Log("found");
                walkPoint = hit.position;
                walkPointIsSet = true;
            };
        }

        private void ChaseTarget()
        {
            Vector3 targetCircle = enemyTransform.position - target.position;
            //Debug.Log(targetCircle);
            targetCircle = targetCircle.normalized * closestDistance;
            agent.SetDestination(target.position + targetCircle);
        }
    }
}
