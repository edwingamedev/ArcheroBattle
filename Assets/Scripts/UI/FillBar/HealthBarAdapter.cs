using EdwinGameDev.Combat.Health;
using UnityEngine;

namespace EdwinGameDev.UI.FillBar
{
    public class HealthBarAdapter : MonoBehaviour
    {
        [SerializeField] private AnimatedFillBar fillBar;
        private HealthPresenter _presenter;

        public void Setup(IHealth health)
        {
            _presenter = new HealthPresenter(health, fillBar);
        }

        private void OnDestroy()
        {
            _presenter?.Dispose();
        }
    }
}