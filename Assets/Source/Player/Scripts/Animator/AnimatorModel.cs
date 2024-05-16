using System;
using UnityEngine;

namespace Nevalyashka.Brigade.Model
{
    public class AnimatorModel : ISwitchable, IUpdateble
    {
        private Movement _movement;
        private Dragger _dragger;

        public bool IsEnabled { get; private set; }

        public event Action<Vector2> Moving;
        public event Action<bool> Dragging;
        public event Action<bool> Dropping;

        public AnimatorModel(Movement movement, Dragger dragger)
        {
            _movement = movement;
            _dragger = dragger;
        }

        public void Enable()
        {
            IsEnabled = true;

            _dragger.Dragging += OnDragging;
            _dragger.Dropping += OnDropping;
        }

        public void Disable()
        {
            IsEnabled = false;

            _dragger.Dragging -= OnDragging;
            _dragger.Dropping -= OnDropping;
        }

        public void Update(float tick)
        {
            if (IsEnabled == false)
                return;

            Moving?.Invoke(_movement.Direction.normalized);
        }

        private void OnDragging(bool isEasy)
        {
            Dragging?.Invoke(isEasy);
        }

        private void OnDropping(bool isEasy)
        {
            Dropping?.Invoke(isEasy);
        }
    }
}
