using EdwinGameDev.Spawn;
using UnityEngine;

namespace EdwinGameDev.Combat.Attacks
{
    public class ProjectileAttack : IAttack
    {
        private readonly IProjectileSpawner _spawner;
        private readonly Transform _origin;
        public float AttackSpeed => 1;

        public ProjectileAttack(IProjectileSpawner spawner, Transform origin)
        {
            _spawner = spawner;
            _origin = origin;
        }

        public void Execute(Vector3 direction)
        {
            _spawner.SpawnProjectile(_origin.position, direction);
        }
    }
}