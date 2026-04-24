using EdwinGameDev.Target;
using UnityEngine;

namespace EdwinGameDev.Spawn
{
    public interface IProjectileSpawner
    {
        void SpawnProjectile(Vector3 direction, ITarget owner);
    }
}