using Nevalyashka.Brigade.Model;

namespace Nevalyashka.Brigade.Presenter
{
    public class ConstructionTaskBarPresenter : AmountBarPresenter<ConstructionTask>
    {
        public override int MaxAmount => Config.TaskAmountConstruction;

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
            gameObject.SetActive(false);
        }
    }
}
