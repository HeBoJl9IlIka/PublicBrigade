using Nevalyashka.Brigade.Model;
using Nevalyashka.Brigade.Presenter;
using UnityEngine;

namespace Nevalyashka.Brigade.Root
{
    [RequireComponent(typeof(RepairDrawingPresenter))]
    public class RepairDrawingRoot : Root
    {
        private RepairDrawing _model;
        private RepairDrawingPresenter _presenter;

        public override void Compose()
        {
            _model = new RepairDrawing();
            _presenter = GetComponent<RepairDrawingPresenter>();
            _presenter.Init(_model);
        }
    }
}
