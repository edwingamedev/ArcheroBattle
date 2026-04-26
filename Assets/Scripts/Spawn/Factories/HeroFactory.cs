using EdwinGameDev.Animation;
using EdwinGameDev.Character;
using EdwinGameDev.Character.Units;
using EdwinGameDev.Combat.Attacks;
using EdwinGameDev.Combat.Health;
using EdwinGameDev.Movement;
using EdwinGameDev.Target;
using UnityEngine;

namespace EdwinGameDev.Spawn.Factories
{
    public class HeroFactory
    {
        public CharacterAdapter Create(UnitStats unitStats, GameObject unitGo)
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

            // Health
            
            IHealth health = new Health(unitStats.Health);
            
            HealthModule healthModule = new HealthModule(
                health,
                healthAnimation
            );
            
            // Target
            
            targetAdapter.Initialize(healthModule);

            ITarget target = targetAdapter;
            TargetingSystem targetingSystem = new TargetingSystem(target);

            // Attack
            
            IAttack attack = new ProjectileAttack(
                spawner,
                target,
                unitStats.AttackSpeed
            );

            AttackModule attackModule = new AttackModule(
                attack,
                attackAnimation,
                targetingSystem,
                unitGo.transform
            );
            
            // Movement
            
            moveable.Setup(unitStats.MoveSpeed);
            
            MovementModule movementModule = new MovementModule(
                moveable,
                movementAnimation,
                unitStats.MoveSpeed
            );

            // Character setup
            
            character.Initialize(
                movementModule,
                attackModule,
                healthModule
            );

            return character;
        }
    }
}