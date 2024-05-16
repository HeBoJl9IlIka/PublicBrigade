using Nevalyashka.Brigade.Factory;
using Nevalyashka.Brigade.Model;
using Nevalyashka.Brigade.Presenter;
using UnityEngine;

namespace Nevalyashka.Brigade.Root
{
    [RequireComponent(typeof(TasksCounterBarFactory))]
    public class TasksCounterRoot : Root
    {
        private MultiTasksRoot[] _multiTasksRoots;
        private TaskRoot[] _tasksRoots;
        private TasksCounter _tasksCounter;
        private TasksCounterBarFactory _factory;

        public void Init()
        {
            TasksCounterBarPresenter tasksCounterBarPresenter;
            _factory = GetComponent<TasksCounterBarFactory>();
            _multiTasksRoots = GetComponentsInChildren<MultiTasksRoot>(true);
            _tasksRoots = GetComponentsInChildren<TaskRoot>(true);

            Task[] tasks = new Task[_tasksRoots.Length];
            MultiTasks[] multiTasks = new MultiTasks[_multiTasksRoots.Length];

            for (int i = 0; i < _multiTasksRoots.Length; i++)
            {
                _multiTasksRoots[i].Init();
                multiTasks[i] = _multiTasksRoots[i].Model;
            }

            for (int i = 0; i < _tasksRoots.Length; i++)
            {
                _tasksRoots[i].Init();
                tasks[i] = _tasksRoots[i].Model;
            }

            _tasksCounter = new TasksCounter(tasks, multiTasks);
            tasksCounterBarPresenter = _factory.Create(transform);
            tasksCounterBarPresenter.Init(_tasksCounter);
            enabled = true;
        }

        private void OnEnable()
        {
            _tasksCounter.Enable();
        }

        private void OnDisable()
        {
            _tasksCounter.Disable();
        }
    }
}
