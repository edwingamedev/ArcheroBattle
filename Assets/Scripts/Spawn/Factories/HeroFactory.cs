using EdwinGameDev.Animation;
using EdwinGameDev.Character;
using EdwinGameDev.Combat.Attacks;
using EdwinGameDev.Combat.Health;
using EdwinGameDev.Movement;
using EdwinGameDev.Target;
using UnityEngine;

namespace EdwinGameDev.Spawn.Factories
{
    public class HeroFactory
    {
        public CharacterAdapter Create(GameObject unitGo)
        {
            // --- Get components ---
            IMovementAnimation movementAnimation = unitGo.GetComponentInChildren<IMovementAnimation>();
            IAttackAnimation attackAnimation = unitGo.GetComponentInChildren<IAttackAnimation>();
            IHealthAnimation healthAnimation = unitGo.GetComponentInChildren<IHealthAnimation>();

            IMoveable moveable = unitGo.GetComponent<IMoveable>();
            IProjectileSpawner spawner = unitGo.GetComponent<IProjectileSpawner>();

            CharacterAdapter character = unitGo.GetComponent<CharacterAdapter>();
            TargetAdapter targetAdapter = unitGo.GetComponent<TargetAdapter>();

            if (character == null)
            {
                Debug.LogError("Missing CharacterAdapter");
            }

            if (targetAdapter == null)
            {
                Debug.LogError("Missing TargetAdapter");
            }

            if (spawner == null)
            {
                Debug.LogError("Missing IProjectileSpawner");
            }

            IHealth health = new Health(100);
            
            HealthModule healthModule = new HealthModule(
                health,
                healthAnimation
            );
            
            targetAdapter.Initialize(healthModule);

            ITarget target = targetAdapter;
            TargetingSystem targetingSystem = new TargetingSystem(target);

            IAttack attack = new ProjectileAttack(
                spawner,
                target
            );

            MovementModule movementModule = new MovementModule(
                moveable,
                movementAnimation
            );

            AttackModule attackModule = new AttackModule(
                attack,
                attackAnimation,
                targetingSystem,
                unitGo.transform
            );

            character.Initialize(
                movementModule,
                attackModule,
                healthModule
            );

            return character;
        }
    }
}