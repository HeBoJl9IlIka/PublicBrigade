using Nevalyashka.Brigade.Model;
using UnityEngine;

namespace Nevalyashka.Brigade.Presenter
{
    public class PlayerMaterialBarPresenter : AmountBarPresenter<Inventory>
    {
        public override int MaxAmount => Config.MaxAmountInventory;

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
