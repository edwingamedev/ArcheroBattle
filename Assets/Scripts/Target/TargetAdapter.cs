using System;
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

        [SerializeField] private new Collider collider;

        public event Action OnDied;
        
        public void Initialize(HealthModule health)
        {
            HealthModule = health;
            HealthModule.OnDied += OnDiedEventHandler;
        }

        private void OnEnable()
        {
            TargetProvider.AddTarget(this);
        }

        private void OnDisable()
        {
            RemoveTarget();
        }

        private void OnDestroy()
        {
            RemoveTarget();
            HealthModule.OnDied -= OnDiedEventHandler;
        }

        public void TakeDamage(int amount)
        {
            if (!HasHealth())
            {
                return;
            }

            HealthModule.TakeDamage(amount);
        }

        private void OnDiedEventHandler()
        {
            if (collider)
            {
                collider.enabled = false;
            }

            TargetProvider.RemoveTarget(this);
            
            OnDied?.Invoke();
        }

        private void RemoveTarget()
        {
            TargetProvider.RemoveTarget(this);
        }

        private bool HasHealth()
        {
            return HealthModule != null;
        }
    }
}