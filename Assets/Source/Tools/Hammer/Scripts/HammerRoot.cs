using Nevalyashka.Brigade.Model;
using Nevalyashka.Brigade.Presenter;
using UnityEngine;

namespace Nevalyashka.Brigade.Root
{
    [RequireComponent(typeof(HammerPresenter))]
    public class HammerRoot : Root
    {
        private Hammer _model;
        private HammerPresenter _presenter;

        public override void Compose()
        {
            _model = new Hammer(Config.HammerGivingAmount);
            _presenter = GetComponent<HammerPresenter>();
            _presenter.Init(_model);
        }
    }
}
