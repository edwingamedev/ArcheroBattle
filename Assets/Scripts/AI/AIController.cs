using UnityEngine;
using EdwinGameDev.Character;
using EdwinGameDev.Target;

namespace EdwinGameDev.AI
{
    public class AIController : MonoBehaviour
    {
        [SerializeField] private float chaseRange = 15f;
        [SerializeField] private float stopDistance = 2f;

        private MovementModule _movementModule;
        private TargetingSystem _targeting;
        private ITarget _owner;

        private ITarget _currentTarget;

        public void Initialize(
            MovementModule movement,
            ITarget owner)
        {
            _movementModule = movement;
            _owner = owner;

            _targeting = new TargetingSystem(_owner);
        }

        private void Update()
        {
            if (!_owner.IsAlive)
            {
                return;
            }

            UpdateTarget();
            UpdateMovement();
        }

        private void UpdateTarget()
        {
            if (_targeting == null)
            {
                return;
            }

            _currentTarget ??= _targeting.GetClosest(transform.position, chaseRange);
            
            if (_currentTarget == null || _currentTarget.IsAlive == false)
            {
                _currentTarget = null;
                return;
            }

            float distance = Vector3.Distance(transform.position, _currentTarget.Transform.position);

            if (distance > chaseRange)
            {
                _currentTarget = null;
            }
        }

        private void UpdateMovement()
        {
            if (_movementModule == null)
            {
                return;
            }

            if (_currentTarget == null)
            {
                _movementModule.Stop();
                return;
            }

            Vector3 direction = _currentTarget.Transform.position - transform.position;
            float distance = direction.magnitude;

            if (distance <= stopDistance)
            {
                _movementModule.Stop();
                return;
            }

            _movementModule.Move(direction);
        }
    }
}