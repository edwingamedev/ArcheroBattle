namespace EdwinGameDev.AnimationSystem
{
    public interface IUnitAnimator
    {
        void PlayIdle();
        void PlayMove();
        void PlayAttack();
        void PlayDeath();
        void PlayTakeDamage();
    }
}