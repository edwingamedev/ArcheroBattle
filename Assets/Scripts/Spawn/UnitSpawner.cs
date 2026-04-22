using EdwinGameDev.Match;
using EdwinGameDev.Spawn.Factories;
using EdwinGameDev.Target;
using UnityEngine;

namespace EdwinGameDev.Spawn
{
    public class UnitSpawner : MonoBehaviour
    {
        [SerializeField] private GameObject heroPrefab;
        [SerializeField] private MatchManager matchManager;
        
        private HeroSpawnService _spawnService;
        
        private void Awake()
        {
            _spawnService = new HeroSpawnService(new HeroFactory());

            matchManager.OnMatchStarted += InitialSpawn;
        }

        private void OnDestroy()
        {
            matchManager.OnMatchStarted -= InitialSpawn;
        }

        private void InitialSpawn()
        {
            _spawnService.Spawn(heroPrefab, Vector3.zero);
        }
    }
}