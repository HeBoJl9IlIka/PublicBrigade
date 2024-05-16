using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Nevalyashka.Brigade.Model
{
    public class PlayerRouter : ISwitchable
    {
        private InputActionMap _inputActionMap;
        private JoystickModel _joystickModel;
        private List<InputAction> _inputActions;

        public bool IsEnabled { get; private set; }

        public event Action<Config.TypesAction, Vector2> Moving;
        public event Action DraggingDropping;
        public event Action Using;
        public event Action Throwing;
        public event Action<float> Rotating;

        public PlayerRouter(InputActionMap inputActionMap, JoystickModel joystickModel)
        {
            _inputActionMap = inputActionMap;
            _joystickModel = joystickModel;
            _inputActions = new List<InputAction>();
            SetInputActions();
        }

        public void Enable()
        {
            IsEnabled = true;

            foreach (var action in _inputActions)
                action.performed += OnPerformed;

            foreach (var action in _inputActions)
                action.canceled += OnCanceled;

            _joystickModel.Dragging += OnDragging;
        }

        public void Disable()
        {
            IsEnabled = false;

            foreach (var action in _inputActions)
                action.performed -= OnPerformed;

            foreach (var action in _inputActions)
                action.canceled -= OnCanceled;

            _joystickModel.Dragging -= OnDragging;
        }

        private void OnPerformed(InputAction.CallbackContext context)
        {
            switch (context.action.name)
            {
                case nameof(Config.Actions.Move):
                    Moving?.Invoke(Config.TypesAction.Performed, context.ReadValue<Vector2>());
                    break;
                case nameof(Config.Actions.DragDrop):
                    DraggingDropping?.Invoke();
                    break;
                case nameof(Config.Actions.Use):
                    Using?.Invoke();
                    break;
                case nameof(Config.Actions.Throw):
                    Throwing?.Invoke();
                    break;
                case nameof(Config.Actions.Rotation):
                    Rotating?.Invoke(context.ReadValue<float>());
                    break;
                default:
                    throw new ArgumentNullException(context.action.name);
            }
        }

        private void OnCanceled(InputAction.CallbackContext context)
        {
            switch (context.action.name)
            {
                case nameof(Config.Actions.Move):
                    Moving?.Invoke(Config.TypesAction.Canceled, context.ReadValue<Vector2>());
                    break;
            }
        }

        private void OnDragging(Vector2 direction)
        {
            Moving?.Invoke(Config.TypesAction.Performed, direction);
        }

        private void SetInputActions()
        {
            foreach (var action in Enum.GetValues(typeof(Config.Actions)))
            {
                InputAction inputAction = _inputActionMap.FindAction(action.ToString());
                _inputActions.Add(inputAction);
            }
        }
    }
}
