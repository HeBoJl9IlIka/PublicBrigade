using System;

namespace Nevalyashka.Brigade.Model
{
    public abstract class Hands<T> : ISwitchable
    {
        protected T TargetObject;

        private PlayerRouter _playerRouter;

        public T CurrentObject { get; protected set; }
        public bool IsEnabled { get; private set; }

        public Hands(PlayerRouter playerRouter)
        {
            _playerRouter = playerRouter;
        }

        public void Enable()
        {
            IsEnabled = true;

            _playerRouter.Using += OnUsing;
            _playerRouter.DraggingDropping += OnDraggingDropping;
            _playerRouter.Throwing += OnThrowing;
            _playerRouter.Rotating += OnRotating;
        }

        public void Disable()
        {
            IsEnabled = false;

            _playerRouter.Using -= OnUsing;
            _playerRouter.DraggingDropping -= OnDraggingDropping;
            _playerRouter.Throwing -= OnThrowing;
            _playerRouter.Rotating -= OnRotating;
        }

        public abstract void SetObject(T targetObject);

        public abstract void Cancel();

        protected virtual void OnUsing() { }

        protected virtual void OnDraggingDropping() { }

        protected virtual void OnThrowing() { }

        protected virtual void OnRotating(float value) { }
    }
}
