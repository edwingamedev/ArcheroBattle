using System;

namespace EdwinGameDev.Animation
{
    public interface IAttackAnimation
    {
        void SetAttacking(bool isAttacking);
        void SetOnAttackHit(Action callback);
        void OnAttackHit();
    }
}