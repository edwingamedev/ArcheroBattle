using EdwinGameDev.Animation;
using EdwinGameDev.Character;
using EdwinGameDev.Combat.Attacks;
using EdwinGameDev.Combat.Health;
using EdwinGameDev.Movement;
using UnityEngine;

namespace EdwinGameDev.Spawn.Factories
{
    public class HeroFactory
    {
        public CharacterControllerFacade Create(GameObject unitGo)
        {
            var movementAnimation = unitGo.GetComponentInChildren<IMovementAnimation>();
            var attackAnimation = unitGo.GetComponentInChildren<IAttackAnimation>();
            var healthAnimation = unitGo.GetComponentInChildren<IHealthAnimation>();
            
            IMoveable moveable = unitGo.GetComponent<IMoveable>();
            IProjectileSpawner spawner = unitGo.GetComponent<IProjectileSpawner>();
            
            var health = new Health(100);
            IAttack attack = new ProjectileAttack(spawner, unitGo.transform);
            
            MovementModule movementModule = new MovementModule(moveable, movementAnimation);

            AttackModule attackModule = new AttackModule(
                attack,
                attackAnimation
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