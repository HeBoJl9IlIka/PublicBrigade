using Nevalyashka.Brigade.Model;
using Nevalyashka.Brigade.Presenter;
using UnityEngine;

namespace Nevalyashka.Brigade.Root
{
    [RequireComponent(typeof(WaterPresenter))]
    public class WaterRoot : Root
    {
        private Water _water;
        private WaterPresenter _waterPresenter;

        public override void Compose()
        {
            _waterPresenter = GetComponent<WaterPresenter>();
            _water = new Water();
            _waterPresenter.Init(_water);
        }
    }
}
