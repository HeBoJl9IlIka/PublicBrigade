using UnityEngine;

namespace Nevalyashka.Brigade.Model
{
    public class Movement : ISwitchable, IUpdateble
    {
        private PlayerRouter _playerRouter;
        private CameraRotator _cameraRotator;
        private Vector2 _direction;
        private float _moveSpeed;
        private float _speedChangeRate;
        private float _speed;
        private float _currentHorizontalSpeed;

        public bool IsEnabled { get; private set; }
        public Vector2 Direction { get; private set; }
        public float MaxSpeed => _moveSpeed;

        public Movement(PlayerRouter playerRouter, float moveSpeed, float speedChangeRate, CameraRotator cameraRotator)
        {
            _playerRouter = playerRouter;
            _moveSpeed = moveSpeed;
            _speedChangeRate = speedChangeRate;
            _cameraRotator = cameraRotator;
        }

        public void Enable()
        {
            IsEnabled = true;
            _playerRouter.Moving += OnMoving;
        }

        public void Disable()
        {
            IsEnabled = false;
            _playerRouter.Moving -= OnMoving;
        }

        public void Update(float tick)
        {
            if (IsEnabled == false)
                return;

            Move(tick);
        }

        public void SetCharacterVelocity(Vector3 velocity)
        {
            velocity.y = 0;
            _currentHorizontalSpeed = velocity.magnitude;
        }

        private void OnMoving(Config.TypesAction typesAction, Vector2 direction)
        {
            if (typesAction == Config.TypesAction.Performed)
                _direction = InvertInput(direction);

            if (typesAction == Config.TypesAction.Canceled)
                _direction = Vector2.zero;
        }

        private void Move(float tick)
        {
            float targetSpeed = _moveSpeed;
            float magnitude = Mathf.Clamp(_direction.magnitude, 0, 1);

            if (_direction == Vector2.zero)
                targetSpeed = 0;

            if (_currentHorizontalSpeed < targetSpeed - Config.MovingSpeedOffset || _currentHorizontalSpeed > targetSpeed + Config.MovingSpeedOffset)
            {
                _speed = Mathf.Lerp(_currentHorizontalSpeed, targetSpeed * magnitude, tick * _speedChangeRate);
                _speed = Mathf.Round(_speed * 1000f) / 1000f;
            }
            else
            {
                _speed = targetSpeed;
            }

            Direction = _direction.normalized * _speed * tick;
        }

        private Vector2 InvertInput(Vector2 direction)
        {
            if (_cameraRotator.CurrentAngle == 90)
                return new Vector2(direction.y, direction.x * -1);

            if (_cameraRotator.CurrentAngle == -90)
                return new Vector2(direction.y * -1, direction.x);

            if (_cameraRotator.CurrentAngle == -180)
                return direction * -1;

            return direction;
        }
    }
}
