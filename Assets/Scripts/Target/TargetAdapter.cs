using EdwinGameDev.Combat.Health;
using UnityEngine;

namespace EdwinGameDev.Target
{
    public class TargetAdapter : MonoBehaviour, ITarget
    {
        [field: SerializeField] public bool IsPlayer { get; set; }
        [SerializeField] private HealthAdapter healthAdapter;
        public Transform Transform => transform;
        public bool IsAlive => HasHealth() && healthAdapter.Health.IsAlive;

        private void OnEnable()
        {
            TargetProvider.AddTarget(this);

            if (!HasHealth())
            {
                return;
            }

            healthAdapter.Health.OnDied += OnDied;
        }

        private void OnDisable()
        {
            Cleanup();
        }

        private void OnDestroy()
        {
            Cleanup();
        }
        
        private bool HasHealth()
        {
            return healthAdapter && healthAdapter.Health != null;
        }

        private void OnDied()
        {
            TargetProvider.RemoveTarget(this);
        }

        private void Cleanup()
        {
            TargetProvider.RemoveTarget(this);

            if (!HasHealth())
            {
                return;
            }

            healthAdapter.Health.OnDied -= OnDied;
        }
    }
}