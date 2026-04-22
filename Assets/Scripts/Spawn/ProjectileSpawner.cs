using EdwinGameDev.Combat.Projectiles;
using UnityEngine;

namespace EdwinGameDev.Spawn
{
    public class ProjectileSpawner : MonoBehaviour, IProjectileSpawner
    {
        [SerializeField] private GameObject projectilePrefab;

        public void SpawnProjectile(Vector3 position, Vector3 direction)
        {
            GameObject projectile = Instantiate(projectilePrefab, position, Quaternion.LookRotation(direction));

            if (projectile.TryGetComponent(out Projectile proj))
            {
                proj.Initialize(direction);
            }
        }
    }
}