using System;

namespace EdwinGameDev.Combat.Health
{
    public class Health : IHealth
    {
        public int Current { get; private set; }
        public int Max { get; private set; }

        public bool IsAlive => Current > 0;

        public event Action<int, int, int> OnHealthChanged;
        public event Action OnDied;

        public Health(int max)
        {
            Max = max;
            Current = max;
        }

        public void TakeDamage(int amount)
        {
            if (!IsAlive)
            {
                return;
            }

            Current -= amount;
            
            if (Current < 0)
            {
                Current = 0;
            }

            OnHealthChanged?.Invoke(Current, Max, amount);

            if (Current == 0)
            {
                OnDied?.Invoke();
            }
        }
    }
}