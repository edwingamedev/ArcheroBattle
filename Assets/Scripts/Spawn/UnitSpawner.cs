using System;
using EdwinGameDev.Character;
using EdwinGameDev.Match;
using EdwinGameDev.Spawn.Factories;
using EdwinGameDev.Target;
using EdwinGameDev.UI.FillBar;
using UnityEngine;

namespace EdwinGameDev.Spawn
{
    public class UnitSpawner : MonoBehaviour
    {
        [SerializeField] private GameObject heroPrefab;
        [SerializeField] private MatchManager matchManager;
        [SerializeField] private HealthBarAdapter healthBarPrefab;
        [SerializeField] private Transform uiCanvas;

        private HeroSpawnService _spawnService;

        public event Action<CharacterAdapter> OnHeroSpawn;
        private CharacterAdapter _playerCharacter;

        private void Awake()
        {
            _spawnService = new HeroSpawnService(new HeroFactory());

            matchManager.OnMatchStarted += InitialSpawn;
            matchManager.OnStageCompleted += RepositionCharacter;
        }

        private void OnDestroy()
        {
            matchManager.OnMatchStarted -= InitialSpawn;
            matchManager.OnStageCompleted -= RepositionCharacter;
        }

        private void InitialSpawn()
        {
            CharacterAdapter character = _spawnService.Spawn(heroPrefab, Vector3.zero);

            TargetAdapter targetAdapter = character.GetComponent<TargetAdapter>();
            HealthBarAdapter healthBar = Instantiate(healthBarPrefab, uiCanvas);

            healthBar.Initialize(
                targetAdapter.HealthModule.Health,
                character.transform,
                new Vector3(0, 3.5f, 0)
            );

            _playerCharacter = character;

            OnHeroSpawn?.Invoke(character);
        }

        private void RepositionCharacter()
        {
            _playerCharacter.transform.position = Vector3.zero;
            _playerCharacter.Stop();
        }
    }
}