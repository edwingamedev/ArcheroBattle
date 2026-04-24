using EdwinGameDev.Animation;
using EdwinGameDev.Character;
using EdwinGameDev.Combat.Health;
using EdwinGameDev.Target;
using UnityEngine;

namespace EdwinGameDev.Spawn.Factories
{
    public class EnemyFactory
    {
        public CharacterAdapter Create(GameObject prefab, Vector3 position)
        {
            GameObject enemyGo = Object.Instantiate(prefab, position, Quaternion.identity);

            CharacterAdapter character = enemyGo.GetComponent<CharacterAdapter>();
            TargetAdapter targetAdapter = enemyGo.GetComponent<TargetAdapter>();

            IHealthAnimation healthAnimation = enemyGo.GetComponentInChildren<IHealthAnimation>();

            if (character == null)
            {
                Debug.LogError("Missing CharacterAdapter on Enemy");
            }

            if (targetAdapter == null)
            {
                Debug.LogError("Missing TargetAdapter on Enemy");
            }

            IHealth health = new Health(50);

            HealthModule healthModule = new HealthModule(
                health,
                healthAnimation
            );

            targetAdapter.Initialize(healthModule);
            character.Initialize(
                movement: null,
                attack: null,
                health: healthModule
            );

            return character;
        }
    }
}