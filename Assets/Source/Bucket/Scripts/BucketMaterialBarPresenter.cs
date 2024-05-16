using Nevalyashka.Brigade.Model;

namespace Nevalyashka.Brigade.Presenter
{
    public class BucketMaterialBarPresenter : AmountBarPresenter<Bucket>
    {
        public override int MaxAmount => Config.MaxAmountBucket;

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
