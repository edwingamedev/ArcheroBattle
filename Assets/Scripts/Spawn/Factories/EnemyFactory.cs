using EdwinGameDev.Combat.Health;
using UnityEngine;

namespace EdwinGameDev.Spawn.Factories
{
    public class EnemyFactory
    {
        public GameObject Create(GameObject prefab, Vector3 position)
        {
            GameObject enemyGo = Object.Instantiate(prefab, position, Quaternion.identity);
            
            Health health = new Health(50);
            
            HealthAdapter healthAdapter = enemyGo.GetComponent<HealthAdapter>();
            healthAdapter.Initialize(health);
            
            return enemyGo;
        }
    }
}