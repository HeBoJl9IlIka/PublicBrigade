using Nevalyashka.Brigade.Factory;
using Nevalyashka.Brigade.Model;
using Nevalyashka.Brigade.Presenter;
using UnityEngine;

namespace Nevalyashka.Brigade.Root
{
    [RequireComponent(typeof(ConstructionMaterialTaskPresenter))]
    [RequireComponent(typeof(ConstructionMaterialTaskBarFactory))]
    public class ConstructionMaterialTaskRoot : TaskRoot
    {
        [SerializeField] private Config.TypeConstructionMaterial _targetMaterial;
        [SerializeField] private int _targetCompletionPercentage;

        private ConstructionMaterialTask _task;
        private ConstructionMaterialTaskPresenter _taskPresenter;
        private ConstructionMaterialTaskBarFactory _taskBarFactory;

        public override Task Model => _task;

        public override void Init()
        {
            if (enabled)
                return;

            _taskPresenter = GetComponent<ConstructionMaterialTaskPresenter>();
            _taskBarFactory = GetComponent<ConstructionMaterialTaskBarFactory>();
            _task = new ConstructionMaterialTask(_targetCompletionPercentage, _targetMaterial);
            _taskPresenter.Init(_task);
            ConstructionMaterialTaskBarPresenter barPresenter = _taskBarFactory.Create(transform);
            barPresenter.Init(_task);
            enabled = true;
        }
    }
}
