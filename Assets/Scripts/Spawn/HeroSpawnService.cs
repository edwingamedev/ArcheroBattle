using EdwinGameDev.Character;
using EdwinGameDev.Combat.Health;
using EdwinGameDev.Input;
using EdwinGameDev.Spawn.Factories;
using EdwinGameDev.Target;
using UnityEngine;

namespace EdwinGameDev.Spawn
{
    public class HeroSpawnService
    {
        private readonly HeroFactory _factory;

        public HeroSpawnService(HeroFactory factory)
        {
            _factory = factory;
        }

        public CharacterControllerFacade Spawn(GameObject prefab, Vector3 position)
        {
            GameObject heroGo = Object.Instantiate(prefab, position, Quaternion.identity);
            CharacterControllerFacade character = _factory.Create(heroGo);

            heroGo.GetComponent<PlayerInputAdapter>()
                .Initialize(character);
            
            heroGo.GetComponent<CharacterAdapter>()
                .Initialize(character);
            
            return character;
        }
    }
}