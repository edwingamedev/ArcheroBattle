using System;
using EdwinGameDev.PlayerService;
using UnityEngine;

namespace EdwinGameDev.Match
{
    public class MatchManager : MonoBehaviour
    {
        public event Action OnMatchStarted;
        public event Action OnMatchEnded;
        public event Action OnMatchReset;
        
        private Player _player;

        private void Start()
        {
            StartMatch();
        }

        public void StartMatch()
        {
            OnMatchStarted?.Invoke();
        }
        
        public void EndMatch()
        {
            OnMatchEnded?.Invoke();
        }
        
        public void ResetMatch()
        {
            _player.RemoveMoney(_player.Money);
            
            OnMatchReset?.Invoke();
        }
    }
}
