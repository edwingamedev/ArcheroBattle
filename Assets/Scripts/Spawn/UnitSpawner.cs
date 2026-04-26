using System;
using EdwinGameDev.Character;
using EdwinGameDev.Character.Units;
using EdwinGameDev.Match;
using EdwinGameDev.Spawn.Factories;
using EdwinGameDev.Target;
using EdwinGameDev.UI.FillBar;
using UnityEngine;

namespace EdwinGameDev.Spawn
{
    public class UnitSpawner : MonoBehaviour
    {
        [SerializeField] private UnitDefinition unitDefinition;
        
        [SerializeField] private MatchManager matchManager;
        [SerializeField] private HealthBarAdapter healthBarPrefab;
        [SerializeField] private Transform uiCanvas;

        private HeroSpawnService _spawnService;
        private CharacterAdapter _character;
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
            if (_character != null)
            {
                Reset();
                return;
            }

            _character = _spawnService.Spawn(unitDefinition, Vector3.zero);

            TargetAdapter targetAdapter = _character.GetComponent<TargetAdapter>();
            HealthBarAdapter healthBar = Instantiate(healthBarPrefab, uiCanvas);

            healthBar.Initialize(
                targetAdapter.HealthModule.Health,
                _character.transform,
                new Vector3(0, 3.5f, 0)
            );

            _playerCharacter = _character;

            OnHeroSpawn?.Invoke(_character);
        }

        private void Reset()
        {
            RepositionCharacter();
        }

        private void RepositionCharacter()
        {
            _playerCharacter.transform.position = Vector3.zero;
            _playerCharacter.Stop();
        }
    }
}