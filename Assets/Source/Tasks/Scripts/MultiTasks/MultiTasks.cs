using System;

namespace Nevalyashka.Brigade.Model
{
    public class MultiTasks : ISwitchable
    {
        private Task[] _tasks;
        private int _currentTaskNumber;

        public bool IsEnabled { get; private set; }

        public event Action Completed;

        public MultiTasks(Task[] modelsTasks)
        {
            _tasks = modelsTasks;

            for (int i = 0; i < _tasks.Length; i++)
            {
                if (i != _currentTaskNumber)
                    _tasks[i].ChangeLayer(Config.LayerNumberQueueTask);
            }
        }

        public void Enable()
        {
            IsEnabled = true;

            foreach (var task in _tasks)
                task.Completed += OnCompleted;
        }

        public void Disable()
        {
            IsEnabled = false;

            foreach (var task in _tasks)
                task.Completed -= OnCompleted;
        }

        private void OnCompleted()
        {
            ++_currentTaskNumber;

            if (_tasks.Length == _currentTaskNumber)
            {
                Completed?.Invoke();
                return;
            }

            _tasks[_currentTaskNumber].ChangeLayer(Config.LayerNumberCurrentTask);
        }
    }
}
