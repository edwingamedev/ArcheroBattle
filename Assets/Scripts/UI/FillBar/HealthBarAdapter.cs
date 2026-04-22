using EdwinGameDev.Combat.Health;
using UnityEngine;

namespace EdwinGameDev.UI.FillBar
{
    public class HealthBarAdapter : MonoBehaviour
    {
        [SerializeField] private FillBar fillBar;
        [SerializeField] private Vector3 offset;

        private Camera _cam;
        private Transform _target;
        private IHealth _health;

        private void Awake()
        {
            _cam = Camera.main;
        }

        private void LateUpdate()
        {
            if (!_target)
            {
                return;
            }

            Vector3 screenPos = _cam.WorldToScreenPoint(_target.position + offset);
            transform.position = screenPos;
        }

        public void Initialize(IHealth health, Transform target)
        {
            _target = target;

            _health = health;
            _health.OnHealthChanged += OnHealthChanged;
            _health.OnDied += OnDied;

            OnHealthChanged(_health.Current, _health.Max, 0);
        }

        private void OnHealthChanged(int current, int max, int delta)
        {
            fillBar.UpdateUIEventHandler(current, max, delta);
        }
        
        private void OnDied()
        {
            Destroy(gameObject);
        }

        private void OnDestroy()
        {
            if (_health == null)
            {
                return;
            }

            _health.OnHealthChanged -= OnHealthChanged;
            _health.OnDied -= OnDied;
        }
    }
}