using System;
using EdwinGameDev.Spawn;
using EdwinGameDev.Stage;
using UnityEngine;

namespace EdwinGameDev.Match
{
    public class MatchManager : MonoBehaviour
    {
        //Match
        public event Action OnMatchStarted;
        public event Action OnMatchEnded;
        public event Action OnMatchReset;

        // Stage
        [SerializeField] private StageContainer stageContainer;
        [SerializeField] private EnemySpawner enemySpawner;

        private Stage.Stage _currentStageGo;
        private int _currentStageIndex = 0;
        public event Action OnStageStarted;
        public event Action OnStageCompleted;

        private void Start()
        {
            StartMatch();
        }

        private void SpawnStage()
        {
            if (_currentStageIndex >= stageContainer.stages.Length)
            {
                EndMatch();
                return;
            }

            if (_currentStageGo)
            {
                Destroy(_currentStageGo.gameObject);
            }

            var stagePrefab = stageContainer.stages[_currentStageIndex];
            _currentStageGo = Instantiate(stagePrefab);
            _currentStageGo.Initialize(enemySpawner, this);
        }

        public void StartMatch()
        {
            OnMatchStarted?.Invoke();
            StartStage();
        }

        public void StartStage()
        {
            SpawnStage();
            OnStageStarted?.Invoke();
        }

        public void CompleteStage()
        {
            _currentStageIndex++;
            OnStageCompleted?.Invoke();

            StartStage();
        }

        public void EndMatch()
        {
            OnMatchEnded?.Invoke();
        }

        public void ResetMatch()
        {
            OnMatchReset?.Invoke();
        }
    }
}