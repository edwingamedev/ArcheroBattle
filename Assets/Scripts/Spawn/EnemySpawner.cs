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
        
        private readonly EnemyFactory _factory = new EnemyFactory();

        public CharacterAdapter Spawn(Vector3 position)
        {
            CharacterAdapter character = _factory.Create(enemyPrefab, position);
            TargetAdapter targetAdapter = character.GetComponent<TargetAdapter>();
            HealthBarAdapter healthBar = Instantiate(healthBarPrefab, uiCanvas);

            healthBar.Initialize(
                targetAdapter.HealthModule.Health,
                character.transform
            );

            return character;
        }
    }
}