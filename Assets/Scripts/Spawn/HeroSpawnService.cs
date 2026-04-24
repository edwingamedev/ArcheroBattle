using EdwinGameDev.Character;
using EdwinGameDev.Input;
using EdwinGameDev.Spawn.Factories;
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

        public CharacterAdapter Spawn(GameObject prefab, Vector3 position)
        {
            GameObject heroGo = Object.Instantiate(prefab, position, Quaternion.identity);
            CharacterAdapter character = _factory.Create(heroGo);
            
            heroGo.GetComponent<PlayerInputAdapter>()
                .Initialize(character);

            return character;
        }
    }
}