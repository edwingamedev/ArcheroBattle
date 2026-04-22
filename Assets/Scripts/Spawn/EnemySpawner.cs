using EdwinGameDev.Combat.Health;
using EdwinGameDev.Spawn.Factories;
using EdwinGameDev.UI.FillBar;
using UnityEngine;

namespace EdwinGameDev.Spawn
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private GameObject enemyPrefab;
        [SerializeField] private HealthBarAdapter healthBarPrefab;
        [SerializeField] private Transform uiCanvas;
        
        private void Start()
        {
            EnemyFactory factory = new EnemyFactory();

            for (int i = 0; i < 3; i++)
            {
                GameObject enemyGo = factory.Create(enemyPrefab, new Vector3(i * 2f, 0, 5f));
                HealthAdapter healthAdapter = enemyGo.GetComponent<HealthAdapter>();
                HealthBarAdapter healthBarAdapter = Instantiate(healthBarPrefab, uiCanvas);
                
                healthBarAdapter.Initialize(healthAdapter.Health, enemyGo.transform);
            }
        }

    }
}