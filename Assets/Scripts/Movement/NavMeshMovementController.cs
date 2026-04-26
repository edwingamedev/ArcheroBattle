using UnityEngine;
using UnityEngine.AI;

namespace EdwinGameDev.Movement
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class NavMeshMovementController : MonoBehaviour, IMoveable
    {
        private float _moveSpeed = 3.5f;

        private NavMeshAgent _agent;
        private Vector3 _direction;

        private void Awake()
        {
            _agent = GetComponent<NavMeshAgent>();
        }

        public void Setup(float movementSpeed)
        {
            _moveSpeed = movementSpeed;
            _agent.speed = _moveSpeed;
            _agent.updateRotation = true;
        }

        public void SetDirection(Vector3 direction)
        {
            if (!_agent.isOnNavMesh)
            {
                return;
            }

            if (direction == Vector3.zero)
            {
                Stop();
                return;
            }

            Vector3 destination = transform.position + direction.normalized * 2f;

            if (NavMesh.SamplePosition(destination, out NavMeshHit hit, 2f, NavMesh.AllAreas))
            {
                _agent.SetDestination(hit.position);
            }
        }

        public void Stop()
        {
            _direction = Vector3.zero;
            _agent.ResetPath();
        }
    }
}