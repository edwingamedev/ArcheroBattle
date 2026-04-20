using EdwinGameDev.AnimationSystem;
using EdwinGameDev.MovementSystem;
using UnityEngine;

namespace EdwinGameDev.Characters
{
    public class CharacterControllerFacade
    {
        private readonly IMoveable _movement;
        private readonly IAttacker _attack;
        private readonly IAttackable _health;
        private readonly IUnitAnimator _animator;

        public CharacterControllerFacade(
            IMoveable movement,
            IAttacker attack,
            IAttackable health,
            IUnitAnimator animator)
        {
            _movement = movement;
            _attack = attack;
            _health = health;
            _animator = animator;
        }

        public void SetDirection(Vector3 dir)
        {
            if (IsDead())
            {
                return;
            }

            if (dir.magnitude > 0)
            {
                _movement.SetDirection(dir);
                _animator.PlayMove();
                return;
            }

            _movement.Stop();
            _animator.PlayIdle();
        }

        public void Attack()
        {
            if (IsDead())
            {
                return;
            }

            _attack.Attack();
            _animator.PlayAttack();
        }

        public void TakeDamage(int dmg)
        {
            _health.TakeDamage(dmg);

            if (IsDead())
            {
                _animator.PlayDeath();
            }
        }
        
        private bool IsDead()
        {
            return _health is { IsAlive: false };
        }
    }
}