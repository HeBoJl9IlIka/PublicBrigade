using System;

namespace Nevalyashka.Brigade.Model
{
    public class Task : ISwitchable
    {
        public readonly int TargetCompletionPercentage;

        protected int CurrentCompletionPercentage;

        private bool IsCompleted => TargetCompletionPercentage == CurrentCompletionPercentage;

        public int TargetAmount => TargetCompletionPercentage - CurrentCompletionPercentage;
        public bool IsEnabled { get; private set; }

        public event Action Enabled;
        public event Action Disabled;
        public event Action Selected;
        public event Action Canceled;
        public event Action Completed;
        public event Action<int> Changed;
        public event Action ShowingTarget;
        public event Action HidingTarget;
        public event Action<int> LayerChanged;

        public Task(int targetAmount)
        {
            TargetCompletionPercentage = targetAmount;
        }

        public void Enable()
        {
            IsEnabled = true;

            Enabled?.Invoke();
        }

        public void Disable()
        {
            IsEnabled = false;

            Disabled?.Invoke();
        }

        public void Select()
        {
            Selected?.Invoke();
        }

        public void Cancel()
        {
            Canceled?.Invoke();
        }

        public void ShowTarget()
        {
            if (IsCompleted)
                return;

            ShowingTarget?.Invoke();
        }

        public void HideTarget()
        {
            if (IsCompleted)
                return;

            HidingTarget?.Invoke();
        }

        public void ChangeLayer(int number)
        {
            LayerChanged?.Invoke(number);
        }

        public void TryDo<T>(int amount, T obj = default)
        {
            if (CanDo(obj) == false)
                return;

            ExecuteByTryDo();
            CurrentCompletionPercentage += amount;

            if (CurrentCompletionPercentage >= TargetCompletionPercentage)
                Completed?.Invoke();

            Changed?.Invoke(CurrentCompletionPercentage);
        }

        protected virtual void ExecuteByTryDo()
        {
        }

        protected virtual bool CanDo<T>(T obj = default)
        {
            return true;
        }
    }
}
