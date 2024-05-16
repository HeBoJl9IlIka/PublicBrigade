namespace Nevalyashka.Brigade.Model
{
    public class TaskGoalIndicator
    {
        private Task[] _tasks;

        public TaskGoalIndicator(Task[] tasks)
        {
            _tasks = tasks;
        }

        public void ShowTaskTarget()
        {
            foreach (var task in _tasks)
            {
                if (task != null)
                    task.ShowTarget();
            }
        }

        public void HideTaskTarget()
        {
            foreach (var task in _tasks)
            {
                if (task != null)
                    task.HideTarget();
            }
        }
    }
}
