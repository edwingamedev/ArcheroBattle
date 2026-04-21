using System;

namespace EdwinGameDev.Animation
{
    public interface IAttackAnimation
    {
        void PlayAttack();
        void SetOnAttackHit(Action callback);
        void OnAttackHit();
    }
}