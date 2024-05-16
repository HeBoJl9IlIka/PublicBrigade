using Nevalyashka.Brigade.Factory;
using Nevalyashka.Brigade.Model;
using Nevalyashka.Brigade.Presenter;
using UnityEngine;

namespace Nevalyashka.Brigade.Root
{
    [RequireComponent(typeof(ConstructionTaskPresenter))]
    [RequireComponent(typeof(ConstructionTaskBarFactory))]
    public class ConstructionTaskRoot : TaskRoot
    {
        [SerializeField] private Config.TypeConstructionMaterial _targetMaterial;
        [SerializeField] private int _targetCompletionPercentage;

        private ConstructionTask _task;
        private ConstructionTaskPresenter _taskPresenter;
        private ConstructionTaskBarFactory _taskBarFactory;

        public override Task Model => _task;

        public override void Init()
        {
            if (enabled)
                return;

            _taskPresenter = GetComponent<ConstructionTaskPresenter>();
            _taskBarFactory = GetComponent<ConstructionTaskBarFactory>();
            _task = new ConstructionTask(_targetCompletionPercentage, _targetMaterial);
            _taskPresenter.Init(_task);
            ConstructionTaskBarPresenter barPresenter = _taskBarFactory.Create(transform);
            barPresenter.Init(_task);
            enabled = true;
        }
    }
}
