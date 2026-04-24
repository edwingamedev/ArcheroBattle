using System;
using EdwinGameDev.Animation;
using EdwinGameDev.Combat.Health;

namespace EdwinGameDev.Character
{
    public class HealthModule
    {
        public IHealth Health { get; }
        private readonly IHealthAnimation _animation;
        public bool IsAlive => Health.IsAlive;

        public event Action OnDied;

        public HealthModule(IHealth health, IHealthAnimation animation)
        {
            Health = health;
            _animation = animation;
            
            Health.OnDied += HealthOnDied;
        }
        
        public void TakeDamage(int amount)
        {
            Health.TakeDamage(amount);
            _animation.TakeDamage();
        }
        
        private void HealthOnDied()
        {
            _animation.SetDeath(true);
            OnDied?.Invoke();
        }
    }
}