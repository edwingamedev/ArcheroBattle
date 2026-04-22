using UnityEngine;

namespace EdwinGameDev.Combat.Attacks
{
    public interface IAttack
    {
        void Execute(Vector3 direction);
        float AttackSpeed { get; }
    }
}