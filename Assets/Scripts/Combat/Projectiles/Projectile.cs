using EdwinGameDev.Target;
using UnityEngine;

namespace EdwinGameDev.Combat.Projectiles
{
    public class Projectile : MonoBehaviour
    {
        [SerializeField] private float speed = 10f;
        [SerializeField] private int damage = 10;

        private Vector3 _direction;

        private ITarget _owner;

        public void Initialize(Vector3 direction, ITarget target)
        {
            _owner = target;
            _direction = direction.normalized;
            Destroy(gameObject, 5f);
        }

        private void Update()
        {
            transform.position += _direction * (speed * Time.deltaTime);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out ITarget target))
            {
                if (target == _owner)
                {
                    return;
                }

                target.TakeDamage(damage);
            }

            Destroy(gameObject);
        }
    }
}