using EdwinGameDev.Spawn;
using EdwinGameDev.Target;
using UnityEngine;

namespace EdwinGameDev.Combat.Attacks
{
    public class ProjectileAttack : IAttack
    {
        private readonly IProjectileSpawner _spawner;
        private readonly ITarget _owner;
        public float AttackSpeed => 1;

        public ProjectileAttack(IProjectileSpawner spawner, ITarget owner)
        {
            _spawner = spawner;
            _owner = owner;
        }

        public void Execute(Vector3 direction)
        {
            _spawner.SpawnProjectile(direction, _owner);
        }
    }
}