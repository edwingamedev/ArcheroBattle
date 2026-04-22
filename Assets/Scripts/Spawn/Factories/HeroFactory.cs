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
        public CharacterControllerFacade Create(GameObject unitGo)
        {
            IMovementAnimation movementAnimation = unitGo.GetComponentInChildren<IMovementAnimation>();
            IAttackAnimation attackAnimation = unitGo.GetComponentInChildren<IAttackAnimation>();
            IHealthAnimation healthAnimation = unitGo.GetComponentInChildren<IHealthAnimation>();

            IMoveable moveable = unitGo.GetComponent<IMoveable>();
            IProjectileSpawner spawner = unitGo.GetComponent<IProjectileSpawner>();

            IHealth health = new Health(100);
            IAttack attack = new ProjectileAttack(spawner, unitGo.transform);
            ITarget target = unitGo.GetComponent<ITarget>();

            TargetingSystem targetingSystem = new TargetingSystem(target);

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

            HealthModule healthModule = new HealthModule(
                health,
                healthAnimation
            );

            return new CharacterControllerFacade(
                movementModule,
                attackModule,
                healthModule
            );
        }
    }
}