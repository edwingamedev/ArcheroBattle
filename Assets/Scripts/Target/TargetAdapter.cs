using EdwinGameDev.Character;
using UnityEngine;

namespace EdwinGameDev.Target
{
    public class TargetAdapter : MonoBehaviour, ITarget
    {
        [field: SerializeField] public bool IsPlayer { get; set; }

        public Transform Transform => transform;
        public bool IsAlive => HasHealth() && HealthModule.IsAlive;

        public HealthModule HealthModule { get; private set; }

        [SerializeField] private Collider _collider;

        public void Initialize(HealthModule health)
        {
            HealthModule = health;
        }

        private void OnEnable()
        {
            TargetProvider.AddTarget(this);

            if (!HasHealth())
            {
                return;
            }

            HealthModule.OnDied += OnDied;
        }

        private void OnDisable()
        {
            Cleanup();
        }

        private void OnDestroy()
        {
            Cleanup();
        }

        public void TakeDamage(int amount)
        {
            if (!HasHealth())
            {
                return;
            }

            HealthModule.TakeDamage(amount);
        }

        private void OnDied()
        {
            if (_collider)
            {
                _collider.enabled = false;
            }

            TargetProvider.RemoveTarget(this);
        }

        private void Cleanup()
        {
            TargetProvider.RemoveTarget(this);

            if (!HasHealth())
            {
                return;
            }

            HealthModule.OnDied -= OnDied;
        }
        
        private bool HasHealth()
        {
            return HealthModule != null;
        }
    }
}