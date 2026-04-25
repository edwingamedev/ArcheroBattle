using EdwinGameDev.AI;
using EdwinGameDev.Animation;
using EdwinGameDev.Character;
using EdwinGameDev.Combat.Health;
using EdwinGameDev.Movement;
using EdwinGameDev.Target;
using UnityEngine;

namespace EdwinGameDev.Spawn.Factories
{
    public class EnemyFactory
    {
        public AIController Create(GameObject prefab, Vector3 position, Transform parent)
        {
            GameObject unitGo = Object.Instantiate(prefab, position, Quaternion.Euler(0, 180, 0), parent);

            AIController aiController = unitGo.GetComponent<AIController>();
            TargetAdapter targetAdapter = unitGo.GetComponent<TargetAdapter>();

            IMovementAnimation movementAnimation = unitGo.GetComponentInChildren<IMovementAnimation>();
            IHealthAnimation healthAnimation = unitGo.GetComponentInChildren<IHealthAnimation>();
            
            IMoveable moveable = unitGo.GetComponent<IMoveable>();


            if (targetAdapter == null)
            {
                Debug.LogError("Missing TargetAdapter on Enemy");
            }

            IHealth health = new Health(50);

            HealthModule healthModule = new HealthModule(
                health,
                healthAnimation
            );
            
            MovementModule movementModule = new MovementModule(
                moveable,
                movementAnimation
            );
            
            
            targetAdapter.Initialize(healthModule);
            aiController.Initialize(
                movement: movementModule,
                targetAdapter
            );

            return aiController;
        }
    }
}