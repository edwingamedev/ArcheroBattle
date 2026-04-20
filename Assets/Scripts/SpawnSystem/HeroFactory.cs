using EdwinGameDev.AnimationSystem;
using EdwinGameDev.Characters;
using EdwinGameDev.MovementSystem;
using UnityEngine;

namespace EdwinGameDev.SpawnSystem
{
    public class HeroFactory
    {
        public CharacterControllerFacade Create(GameObject unitGo)
        {
            var movement = unitGo.GetComponent<IMoveable>();
            var animator = unitGo.GetComponent<IUnitAnimator>();
            var health = unitGo.GetComponent<IAttackable>();
            var attack = unitGo.GetComponent<IAttacker>();
            
            return new CharacterControllerFacade(
                movement,
                attack,
                health,
                animator
            );
        }
        
        public CharacterControllerFacade Create(
            IMoveable movement,
            IAttacker attack,
            IAttackable health,
            IUnitAnimator animator)
        {
            return new CharacterControllerFacade(
                movement,
                attack,
                health,
                animator
            );
        }
    }
}