using Nevalyashka.Brigade.Model;

namespace Nevalyashka.Brigade.Presenter
{
    public class TasksCounterBarPresenter : AmountBarPresenter<TasksCounter>
    {
        public override int MaxAmount => Model.MaxTasksCount;

        private void OnEnable()
        {
            Model.Changed += OnChanged;
            Model.Completed += OnCompleted;
        }

        private void OnDisable()
        {
            Model.Changed -= OnChanged;
            Model.Completed -= OnCompleted;
        }

        private void OnCompleted()
        {
            //gameObject.SetActive(false);
        }
    }
}
