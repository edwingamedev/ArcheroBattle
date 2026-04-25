using System.Collections.Generic;
using EdwinGameDev.AI;
using EdwinGameDev.Match;
using EdwinGameDev.Spawn;
using EdwinGameDev.Target;
using UnityEngine;

namespace EdwinGameDev.Stage
{
    public class Stage : MonoBehaviour
    {
        [SerializeField] private List<Transform> spawnPoints;
        [SerializeField] private TriggerObject portal;
        
        private MatchManager _matchManager;

        private int _aliveEnemies;

        private void Awake()
        {
            portal.OnTrigger += CompleteStage;
        }

        private void OnDestroy()
        {
            portal.OnTrigger -= CompleteStage;
        }

        public void Initialize(EnemySpawner enemySpawner, MatchManager matchManager)
        {
            _matchManager = matchManager;

            portal.Disable();

            foreach (Transform spawnPoint in spawnPoints)
            {
                AIController enemy = enemySpawner.Spawn(spawnPoint.position, transform);

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
            portal.Enable();
        }
        
        private void CompleteStage()
        {
            _matchManager?.CompleteStage();
        }
    }
}