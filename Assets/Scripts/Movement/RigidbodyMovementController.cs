using UnityEngine;

namespace EdwinGameDev.Movement
{
    [RequireComponent(typeof(Rigidbody))]
    public class RigidbodyMovementController : MonoBehaviour, IMoveable
    {
        [SerializeField] private float moveSpeed = 5f;
        [SerializeField] private float rotationSpeed = 15f;

        private Rigidbody _rb;
        private Vector3 _direction;

        private void Awake()
        {
            _rb = GetComponent<Rigidbody>();
        }

        private void FixedUpdate()
        {
            Move();
            Rotate();
        }

        public void SetDirection(Vector3 direction)
        {
            _direction = direction.normalized;
        }

        public void Stop()
        {
            _direction = Vector3.zero;
            _rb.velocity = new Vector3(0, _rb.velocity.y, 0);
        }

        private void Move()
        {
            Vector3 velocity = _direction * moveSpeed;
            velocity.y = _rb.velocity.y;

            _rb.velocity = velocity;
        }

        private void Rotate()
        {
            if (_direction == Vector3.zero)
            {
                return;
            }

            Quaternion targetRotation = Quaternion.LookRotation(_direction);
            Quaternion smoothRotation = Quaternion.Slerp(
                _rb.rotation,
                targetRotation,
                rotationSpeed * Time.fixedDeltaTime
            );

            _rb.MoveRotation(smoothRotation);
        }
    }
}