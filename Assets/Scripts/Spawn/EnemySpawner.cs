using EdwinGameDev.Character;
using EdwinGameDev.Spawn.Factories;
using EdwinGameDev.Target;
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
                CharacterAdapter character = factory.Create(enemyPrefab, new Vector3(i * 2f, 0, 5f));
                TargetAdapter targetAdapter = character.GetComponent<TargetAdapter>();
                HealthBarAdapter healthBar = Instantiate(healthBarPrefab, uiCanvas);

                healthBar.Initialize(
                    targetAdapter.HealthModule.Health,
                    character.transform
                );
            }
        }
    }
}