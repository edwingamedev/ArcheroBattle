using System;
using EdwinGameDev.Match;
using UnityEngine;
using UnityEngine.UI;

namespace EdwinGameDev.UI.Screens
{
    public class GameOverScreen : ScreenBehaviour
    {
        [SerializeField] private Button playAgainButton;
        private Canvas _canvas;

        [SerializeField] private MatchManager _matchManager;

        private void Awake()
        {
            _canvas = GetComponent<Canvas>();

            ScreenManager.AssignScreen(this);

            playAgainButton.onClick.AddListener(PlayAgain);

            _matchManager.OnMatchEnded += LoadScreen;
        }

        private void OnDestroy()
        {
            _matchManager.OnMatchEnded -= LoadScreen;
        }

        private void LoadScreen()
        {
            ScreenManager.LoadScreen(typeof(GameOverScreen));
        }

        private void PlayAgain()
        {
            _matchManager.PlayAgain();
        }

        public override void OnActivate()
        {
            _canvas.enabled = true;
        }

        public override void OnDeactivate()
        {
            _canvas.enabled = false;
        }
    }
}