using EdwinGameDev.Animation;
using EdwinGameDev.Combat.Attacks;
using EdwinGameDev.Target;
using UnityEngine;

namespace EdwinGameDev.Character
{
    public class AttackModule
    {
        private readonly IAttack _attack;
        private readonly IAttackAnimation _animation;
        private readonly TargetingSystem _targeting;

        private readonly float _cooldownTime;
        private float _timer;

        private ITarget _currentTarget;
        private readonly Transform _origin;

        public AttackModule(
            IAttack attack,
            IAttackAnimation animation,
            TargetingSystem targeting,
            Transform origin)
        {
            _attack = attack;
            _animation = animation;
            _targeting = targeting;
            _origin = origin;

            _cooldownTime = 1f / attack.AttackSpeed;
            _animation?.SetOnAttackHit(OnAttackHit);
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

            Debug.Log("Attacking");

            _timer = _cooldownTime;
            
            _currentTarget = _targeting?.GetClosest(_origin.position, 100f);

            if (_currentTarget == null)
            {
                Debug.Log("No closest target");
                return;
            }

            FaceTarget();

            _animation?.PlayAttack();
        }

        private void FaceTarget()
        {
            if (_currentTarget == null)
            {
                return;
            }

            Vector3 direction =
                (_currentTarget.Transform.position - _origin.position).normalized;

            direction.y = 0;
            
            _origin.forward = direction;
        }

        private void OnAttackHit()
        {
            if (_currentTarget == null)
            {
                return;
            }

            Vector3 dir = (_currentTarget.Transform.position - _origin.position).normalized;

            _attack?.Execute(dir);
        }
    }
}