using UnityEngine;

namespace EdwinGameDev.Target
{
    public interface ITarget
    {
        Transform Transform { get; }
        bool IsAlive { get; }
        bool IsPlayer { get; set; }

        void TakeDamage(int amount);
    }
}