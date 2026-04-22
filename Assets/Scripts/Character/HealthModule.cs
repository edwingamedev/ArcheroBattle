using EdwinGameDev.Animation;
using EdwinGameDev.Combat.Health;

namespace EdwinGameDev.Character
{
    public class HealthModule
    {
        private readonly IHealth _health;
        private readonly IHealthAnimation _animation;
        public bool IsAlive => _health.IsAlive;

        public HealthModule(IHealth health, IHealthAnimation animation)
        {
            _health = health;
            _animation = animation;
        }

        public void TakeDamage(int amount)
        {
            _health.TakeDamage(amount);

            if (!IsAlive)
            {
                _animation.PlayDeath();
            }
        }
    }
}