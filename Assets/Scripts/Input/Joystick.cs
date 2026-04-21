using UnityEngine;
using UnityEngine.EventSystems;

namespace EdwinGameDev.Input
{
    public abstract class Joystick : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
    {
        [SerializeField] private float handleRange = 1;
        [SerializeField] private float deadZone;

        [SerializeField] protected RectTransform background;
        [SerializeField] private RectTransform handle;
        private RectTransform _baseRect;

        private Canvas _canvas;
        private Camera _cam;

        private Vector2 _input = Vector2.zero;

        public float Horizontal => _input.x;
        public float Vertical => _input.y;

        public Vector2 Direction => new(Horizontal, Vertical);

        public float HandleRange
        {
            get => handleRange;
            set => handleRange = Mathf.Abs(value);
        }

        public float DeadZone
        {
            get => deadZone;
            set => deadZone = Mathf.Abs(value);
        }

        protected virtual void Start()
        {
            HandleRange = handleRange;
            DeadZone = deadZone;
            _baseRect = GetComponent<RectTransform>();
            _canvas = GetComponentInParent<Canvas>();
            
            if (_canvas == null)
            {
                Debug.LogError("The Joystick is not placed inside a canvas");
            }

            Vector2 center = new(0.5f, 0.5f);
            background.pivot = center;
            handle.anchorMin = center;
            handle.anchorMax = center;
            handle.pivot = center;
            handle.anchoredPosition = Vector2.zero;
        }

        public virtual void OnPointerDown(PointerEventData eventData)
        {
            OnDrag(eventData);
        }

        public virtual void OnPointerUp(PointerEventData eventData)
        {
            _input = Vector2.zero;
            handle.anchoredPosition = Vector2.zero;
        }
        
        public void OnDrag(PointerEventData eventData)
        {
            _cam = null;
            
            if (_canvas.renderMode == RenderMode.ScreenSpaceCamera)
            {
                _cam = _canvas.worldCamera;
            }

            Vector2 position = RectTransformUtility.WorldToScreenPoint(_cam, background.position);
            Vector2 radius = background.sizeDelta / 2;
            _input = (eventData.position - position) / (radius * _canvas.scaleFactor);

            HandleInput(_input.magnitude, _input.normalized, radius, _cam);
            handle.anchoredPosition = _input * radius * handleRange;
        }

        private void HandleInput(float magnitude, Vector2 normalised, Vector2 radius, Camera cam)
        {
            if (magnitude > deadZone)
            {
                if (magnitude > 1)
                {
                    _input = normalised;
                }

                return;
            }

            _input = Vector2.zero;
        }

        protected Vector2 ScreenPointToAnchoredPosition(Vector2 screenPosition)
        {
            if (!RectTransformUtility.ScreenPointToLocalPointInRectangle(_baseRect, screenPosition, _cam, out Vector2 localPoint))
            {
                return Vector2.zero;
            }

            Vector2 pivotOffset = _baseRect.pivot * _baseRect.sizeDelta;
            return localPoint - (background.anchorMax * _baseRect.sizeDelta) + pivotOffset;
        }
    }
}