using Nevalyashka.Brigade.Model;

namespace Nevalyashka.Brigade.Presenter
{
    public class ConstructionMaterialTaskBarPresenter : AmountBarPresenter<ConstructionMaterialTask>
    {
        public override int MaxAmount => Config.TaskAmountConstructionMaterial;

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
