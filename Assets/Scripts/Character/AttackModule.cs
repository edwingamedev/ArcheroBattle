using EdwinGameDev.Animation;
using EdwinGameDev.Combat.Attacks;

namespace EdwinGameDev.Character
{
    public class AttackModule
    {
        private readonly IAttack _attack;
        private readonly IAttackAnimation _animation;
        
        private readonly float _cooldownTime;
        private float _timer;
        
        public AttackModule(IAttack attack, IAttackAnimation animation)
        {
            _attack = attack;
            _animation = animation;
            
            _cooldownTime = 1f / attack.AttackSpeed;
            _animation.SetOnAttackHit(OnAttackHit);
        }

        public void Tick(float dt)
        {
            if (_timer <= 0f)
            {
                return;
            }

            _timer -= dt;
        }
        
        public void TryAttack()
        {
            if (_timer > 0f)
            {
                return;
            }

            _timer = _cooldownTime;
            _animation.PlayAttack();
        }
        
        private void OnAttackHit()
        {
            _attack.Execute();
        }
    }
}