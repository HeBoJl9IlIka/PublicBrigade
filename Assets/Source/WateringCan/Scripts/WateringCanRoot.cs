using Nevalyashka.Brigade.Factory;
using Nevalyashka.Brigade.Model;
using Nevalyashka.Brigade.Presenter;
using UnityEngine;

namespace Nevalyashka.Brigade.Root
{
    [RequireComponent(typeof(WateringCanAmountBarFactory))]
    [RequireComponent(typeof(WateringCanPresenter))]
    public class WateringCanRoot : Root
    {
        private WateringCan _wateringCan;
        private WateringCanPresenter _wateringCanPresenter;
        private WateringCanAmountBarFactory _barFactory;

        public override void Compose()
        {
            _wateringCan = new WateringCan();
            _wateringCanPresenter = GetComponent<WateringCanPresenter>();
            _wateringCanPresenter.Init(_wateringCan);
            _barFactory = GetComponent<WateringCanAmountBarFactory>();
            WateringCanAmountBarPresenter bucketMaterialBar = _barFactory.Create(transform);
            bucketMaterialBar.Init(_wateringCan);
        }
    }
}
