using UnityEngine;

namespace EdwinGameDev.Character
{
    public class CharacterAdapter : MonoBehaviour
    {
        private MovementModule _movement;
        private AttackModule _attack;
        private HealthModule _health;

        public void Initialize(
            MovementModule movement,
            AttackModule attack,
            HealthModule health)
        {
            _movement = movement;
            _attack = attack;
            _health = health;

            _health.OnDied += _movement.Stop;
        }

        private void Update()
        {
            _attack?.Tick(Time.deltaTime);
        }

        public void Move(Vector3 dir)
        {
            if (!IsAlive())
            {
                return;
            }

            _movement?.Move(dir);

            if (dir.sqrMagnitude < 0.01f)
            {
                _attack?.TryAttack();
            }
        }

        public void Stop()
        {
            _movement?.Stop();
        }
        
        private bool IsAlive()
        {
            return _health == null || _health.IsAlive;
        }
    }
}