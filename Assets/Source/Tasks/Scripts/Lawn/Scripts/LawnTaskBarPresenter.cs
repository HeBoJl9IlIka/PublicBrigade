using Nevalyashka.Brigade.Model;

namespace Nevalyashka.Brigade.Presenter
{
    public class LawnTaskBarPresenter : AmountBarPresenter<LawnTask>
    {
        public override int MaxAmount => Config.TaskAmountWaterToLawn;

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
