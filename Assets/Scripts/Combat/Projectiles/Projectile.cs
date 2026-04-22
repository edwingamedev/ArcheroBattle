using EdwinGameDev.Combat.Health;
using UnityEngine;

namespace EdwinGameDev.Combat.Projectiles
{
    public class Projectile : MonoBehaviour
    {
        [SerializeField] private float speed = 10f;
        [SerializeField] private int damage = 10;

        private Vector3 _direction;

        public void Initialize(Vector3 direction)
        {
            _direction = direction.normalized;
            Destroy(gameObject, 5f);
        }

        private void Update()
        {
            transform.position += _direction * (speed * Time.deltaTime);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!other.TryGetComponent(out IHealth target))
            {
                return;
            }

            target.TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}