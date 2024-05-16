using Nevalyashka.Brigade.Factory;
using Nevalyashka.Brigade.Model;
using Nevalyashka.Brigade.Presenter;
using Unity.VisualScripting;
using UnityEngine;

namespace Nevalyashka.Brigade.Root
{
    [RequireComponent(typeof(LiftablePresenter))]
    public class LiftableRoot : Root
    {
        [SerializeField] private bool _isEasy;

        private Liftable _liftable;
        private LiftablePresenter _liftablePresenter;

        private void Start()
        {
            _liftablePresenter = GetComponent<LiftablePresenter>();
            _liftable = CreateModel();
            _liftablePresenter.Init(_liftable);
        }

        private Liftable CreateModel()
        {
            LiftableModelFactory modelFactory = new LiftableModelFactory();

            if (gameObject.TryGetComponent(out ConstructionMaterialPackagePresenter package))
                return modelFactory.Create<ConstructionMaterialPackage, bool, Null, Null>(package.Model, _isEasy, null, null);

            if (gameObject.TryGetComponent(out WateringCanPresenter wateringCan))
                return modelFactory.Create<WateringCan, bool, Null, Null>(wateringCan.Model, _isEasy, null, null);

            if (gameObject.TryGetComponent(out HammerPresenter hammer))
                return modelFactory.Create<Hammer, bool, Null, Null>(hammer.Model, _isEasy, null, null);

            if (gameObject.TryGetComponent(out RepairDrawingPresenter repairDrawing))
                return modelFactory.Create<RepairDrawing, bool, Null, Null>(repairDrawing.Model, _isEasy, null, null);

            return modelFactory.Create<Null, bool, Null, Null>(null, _isEasy, null, null);
        }
    }
}
