using System.Collections.Generic;
using EdwinGameDev.Character;
using EdwinGameDev.Spawn;
using EdwinGameDev.Target;
using UnityEngine;

namespace EdwinGameDev.Stage
{
    public class Stage : MonoBehaviour
    {
        [SerializeField] private List<Transform> spawnPoints;
        [SerializeField] private EnemySpawner enemySpawner;
        [SerializeField] private GameObject portal;

        private int _aliveEnemies;

        private void Start()
        {
            Initialize();
        }

        public void Initialize()
        {
            portal.SetActive(false);

            foreach (Transform spawnPoint in spawnPoints)
            {
                CharacterAdapter enemy = enemySpawner.Spawn(spawnPoint.position);

                _aliveEnemies++;

                TargetAdapter target = enemy.GetComponent<TargetAdapter>();
                target.OnDied += OnEnemyDied;
            }
        }

        private void OnEnemyDied()
        {
            _aliveEnemies--;

            if (_aliveEnemies <= 0)
            {
                OnStageCleared();
            }
        }

        private void OnStageCleared()
        {
            portal.SetActive(true);
        }
    }
}