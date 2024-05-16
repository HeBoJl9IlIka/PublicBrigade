using System;

namespace Nevalyashka.Brigade.Model
{
    public class TasksCounter : ISwitchable
    {
        private Task[] _tasks;
        private MultiTasks[] _multiTasks;
        private int _tasksCount;
        
        public int MaxTasksCount => _tasks.Length + _multiTasks.Length;
        public bool IsEnabled { get; private set; }

        public event Action<int> Changed;
        public event Action Completed;

        public TasksCounter(Task[] tasks, MultiTasks[] multiTasks)
        {
            _tasks = tasks;
            _multiTasks = multiTasks;
        }

        public void Enable()
        {
            IsEnabled = true;

            if (_tasks.Length > 0)
            {
                foreach (var task in _tasks)
                    task.Completed += OnCompleted;
            }

            if (_multiTasks.Length > 0)
            {
                foreach (var multiTasks in _multiTasks)
                    multiTasks.Completed += OnCompleted;
            }
        }

        public void Disable()
        {
            IsEnabled = false;

            if (_tasks.Length > 0)
            {
                foreach (var task in _tasks)
                    task.Completed -= OnCompleted;
            }

            if (_multiTasks.Length > 0)
            {
                foreach (var multiTasks in _multiTasks)
                    multiTasks.Completed -= OnCompleted;
            }
        }

        private void OnCompleted()
        {
            ++_tasksCount;
            Changed?.Invoke(_tasksCount);

            if (_tasksCount == MaxTasksCount)
                Completed?.Invoke();
        }
    }
}
