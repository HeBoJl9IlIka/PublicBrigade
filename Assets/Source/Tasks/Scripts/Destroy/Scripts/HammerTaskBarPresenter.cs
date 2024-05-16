using Nevalyashka.Brigade.Model;

namespace Nevalyashka.Brigade.Presenter
{
    public class HammerTaskBarPresenter : AmountBarPresenter<HammerTask>
    {
        public override int MaxAmount => Config.TaskAmountDestroy;

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
