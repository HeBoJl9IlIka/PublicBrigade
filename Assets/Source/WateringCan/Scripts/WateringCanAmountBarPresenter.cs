using Nevalyashka.Brigade.Model;

namespace Nevalyashka.Brigade.Presenter
{
    public class WateringCanAmountBarPresenter : AmountBarPresenter<WateringCan>
    {
        public override int MaxAmount => Config.MaxAmountWateringCan;

        private void OnEnable()
        {
            Model.Changed += OnChanged;
        }

        private void OnDisable()
        {
            Model.Changed -= OnChanged;
        }
    }
}
