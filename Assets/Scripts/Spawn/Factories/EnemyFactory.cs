using EdwinGameDev.Combat.Health;
using UnityEngine;

namespace EdwinGameDev.Spawn.Factories
{
    public class EnemyFactory
    {
        public GameObject Create(GameObject prefab, Vector3 position)
        {
            GameObject enemyGO = GameObject.Instantiate(prefab, position, Quaternion.identity);
            
            Health health = new Health(50);
            
            HealthAdapter healthAdapter = enemyGO.GetComponent<HealthAdapter>();
            healthAdapter.Initialize(health);

            return enemyGO;
        }
    }
}