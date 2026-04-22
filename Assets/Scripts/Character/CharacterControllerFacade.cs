using UnityEngine;

namespace EdwinGameDev.Character
{
    public class CharacterControllerFacade
    {
        private readonly MovementModule _movementModule;
        private readonly AttackModule _attackModule;
        private readonly HealthModule _healthModule;
        private bool _isMoving;
        
        public CharacterControllerFacade(
            MovementModule movementModule = null,
            AttackModule attackModule = null,
            HealthModule healthModule = null)
        {
            _movementModule = movementModule;
            _attackModule = attackModule;
            _healthModule = healthModule;
        }

        public void Tick(float deltaTime)
        {
            _attackModule?.Tick(deltaTime);
            
            if (!_isMoving)
            {
                TryAttack();
            }
        }

        public void Move(Vector3 dir)
        {
            if (IsDead())
            {
                return;
            }

            _isMoving = dir.sqrMagnitude > 0.01f;
            
            _movementModule?.Move(dir);
        }

        public void TryAttack()
        {
            if (IsDead())
            {
                return;
            }

            _attackModule?.TryAttack();
        }

        public void TakeDamage(int dmg)
        {
            _healthModule?.TakeDamage(dmg);
        }

        private bool IsDead()
        {
            return _healthModule is { IsAlive: false };
        }
    }
}