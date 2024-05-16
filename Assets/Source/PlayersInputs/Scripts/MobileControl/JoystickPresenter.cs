using Nevalyashka.Brigade.Model;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Nevalyashka.Brigade.Presenter
{
    public class JoystickPresenter : Presenter<JoystickModel>, IPointerDownHandler, IDragHandler, IPointerUpHandler
    {
        [SerializeField] private RectTransform _containerRect;
        [SerializeField] private RectTransform _handleRect;
        [SerializeField] private float _joystickRange = 50f;
        [SerializeField] private float _magnitudeMultiplier = 1f;
        [SerializeField] private bool _invertXOutputValue;
        [SerializeField] private bool _invertYOutputValue;

        void Start()
        {
            SetupHandle();
        }

        private void SetupHandle()
        {
            if (_handleRect)
                UpdateHandleRectPosition(Vector2.zero);
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            OnDrag(eventData);
        }

        public void OnDrag(PointerEventData eventData)
        {
            RectTransformUtility.ScreenPointToLocalPointInRectangle(_containerRect, eventData.position, eventData.pressEventCamera, out Vector2 position);
            position = ApplySizeDelta(position);
            Vector2 clampedPosition = ClampValuesToMagnitude(position);
            Vector2 outputPosition = ApplyInversionFilter(position);
            OutputPointerEventValue(outputPosition * _magnitudeMultiplier);

            if (_handleRect)
                UpdateHandleRectPosition(clampedPosition * _joystickRange);
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            OutputPointerEventValue(Vector2.zero);

            if (_handleRect)
                UpdateHandleRectPosition(Vector2.zero);
        }

        private void OutputPointerEventValue(Vector2 pointerPosition)
        {
            Model.SetDirection(pointerPosition);
        }

        private void UpdateHandleRectPosition(Vector2 newPosition)
        {
            _handleRect.anchoredPosition = newPosition;
        }

        Vector2 ApplySizeDelta(Vector2 position)
        {
            float x = (position.x / _containerRect.sizeDelta.x) * 2.5f;
            float y = (position.y / _containerRect.sizeDelta.y) * 2.5f;
            return new Vector2(x, y);
        }

        Vector2 ClampValuesToMagnitude(Vector2 position)
        {
            return Vector2.ClampMagnitude(position, 1);
        }

        Vector2 ApplyInversionFilter(Vector2 position)
        {
            if (_invertXOutputValue)
                position.x = InvertValue(position.x);

            if (_invertYOutputValue)
                position.y = InvertValue(position.y);

            return position;
        }

        float InvertValue(float value)
        {
            return -value;
        }
    }
}
