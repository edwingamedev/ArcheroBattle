using UnityEngine;
using UnityEngine.EventSystems;

namespace EdwinGameDev.Utils.Joystick
{
    public class FloatingJoystick : Joystick
    {
        private Vector2 _startPos;

        protected override void Start()
        {
            base.Start();
            _startPos = background.anchoredPosition;
        }

        public override void OnPointerDown(PointerEventData eventData)
        {
            SetPosition(eventData.position);

            base.OnPointerDown(eventData);
        }

        public override void OnPointerUp(PointerEventData eventData)
        {
            ResetPosition();

            base.OnPointerUp(eventData);
        }

        private void SetPosition(Vector2 pos)
        {
            background.anchoredPosition = ScreenPointToAnchoredPosition(pos);
        }

        private void ResetPosition()
        {
            background.anchoredPosition = _startPos;
        }
    }
}