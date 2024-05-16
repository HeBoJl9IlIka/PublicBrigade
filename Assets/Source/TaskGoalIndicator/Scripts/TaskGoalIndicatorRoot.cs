using Nevalyashka.Brigade.Model;

namespace Nevalyashka.Brigade.Root
{
    public class TaskGoalIndicatorRoot : Root
    {
        public TaskGoalIndicator Model { get; private set; }

        public void Init()
        {
            TaskRoot[] tasksRoots = GetComponentsInChildren<TaskRoot>(true);

            Task[] tasks = new Task[tasksRoots.Length];

            for (int i = 0; i < tasksRoots.Length; i++)
                tasks[i] = tasksRoots[i].Model;

            Model = new TaskGoalIndicator(tasks);
        }
    }
}
