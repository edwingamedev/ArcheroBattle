using EdwinGameDev.UI.FillBar;

namespace EdwinGameDev.Combat.Health
{
    public class HealthPresenter
    {
        private readonly IHealth _health;
        private readonly FillBar _view;

        public HealthPresenter(IHealth health, FillBar view)
        {
            _health = health;
            _view = view;

            _health.OnHealthChanged += OnHealthChanged;

            // Initialize UI
            _view.UpdateUIEventHandler(_health.Current, _health.Max, 0);
        }

        private void OnHealthChanged(int current, int max, int delta)
        {
            _view.UpdateUIEventHandler(current, max, delta);
        }

        public void Dispose()
        {
            _health.OnHealthChanged -= OnHealthChanged;
        }
    }
}