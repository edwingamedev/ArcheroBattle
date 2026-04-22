using UnityEngine;

namespace EdwinGameDev.Spawn
{
    public interface IProjectileSpawner
    {
        void SpawnProjectile(Vector3 position, Vector3 direction);
    }
}