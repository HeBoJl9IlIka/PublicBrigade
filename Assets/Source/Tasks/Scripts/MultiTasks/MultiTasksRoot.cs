using Nevalyashka.Brigade.Model;
using Nevalyashka.Brigade.Presenter;
using UnityEngine;

namespace Nevalyashka.Brigade.Root
{
    [RequireComponent(typeof(MultiTaskPresenter))]
    public class MultiTasksRoot : Root
    {
        private MultiTasks _multiTasks;

        public MultiTasks Model => _multiTasks;

        public void Init()
        {
            TaskRoot[] tasksRoots = GetComponentsInChildren<TaskRoot>(true);
            Task[] task = new Task[tasksRoots.Length];

            for (int i = 0; i < tasksRoots.Length; i++)
            {
                tasksRoots[i].Init();
                task[i] = tasksRoots[i].Model;
            }

            _multiTasks = new MultiTasks(task);
            enabled = true;
        }

        private void OnEnable()
        {
            _multiTasks.Enable();
        }

        private void OnDisable()
        {
            _multiTasks.Disable();
        }
    }
}
