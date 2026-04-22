using System;

namespace EdwinGameDev.Combat.Health
{
    public interface IHealth
    {
        int Current { get; }
        int Max { get; }
        bool IsAlive { get; }
        
        event Action<int, int, int> OnHealthChanged;
        event Action OnDied;
        
        void TakeDamage(int amount);
    }
}