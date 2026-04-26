using EdwinGameDev.Character;
using EdwinGameDev.Character.Units;
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

        public CharacterAdapter Spawn(UnitDefinition unitDefinition, Vector3 position)
        {
            GameObject heroGo = Object.Instantiate(unitDefinition.prefab.gameObject, position, Quaternion.identity);
            CharacterAdapter character = _factory.Create(unitDefinition.stats, heroGo);

            heroGo.GetComponent<PlayerInputAdapter>().Initialize(character);

            return character;
        }
    }
}