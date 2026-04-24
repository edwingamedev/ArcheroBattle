using EdwinGameDev.Combat.Projectiles;
using EdwinGameDev.Target;
using UnityEngine;

namespace EdwinGameDev.Spawn
{
    public class ProjectileSpawner : MonoBehaviour, IProjectileSpawner
    {
        [SerializeField] private GameObject projectilePrefab;
        [SerializeField] private Transform spawnPoint;
        public void SpawnProjectile(Vector3 direction, ITarget owner)
        {
            GameObject projectile = Instantiate(projectilePrefab, spawnPoint.position, Quaternion.LookRotation(direction));

            if (projectile.TryGetComponent(out Projectile proj))
            {
                proj.Initialize(direction, owner);
            }
        }
    }
}