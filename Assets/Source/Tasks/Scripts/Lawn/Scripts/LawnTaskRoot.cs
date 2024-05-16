using Nevalyashka.Brigade.Factory;
using Nevalyashka.Brigade.Model;
using Nevalyashka.Brigade.Presenter;
using UnityEngine;

namespace Nevalyashka.Brigade.Root
{
    [RequireComponent(typeof(LawnTaskPresenter))]
    [RequireComponent(typeof(LawnTaskBarFactory))]
    public class LawnTaskRoot : TaskRoot
    {
        private LawnTask _task;
        private LawnTaskPresenter _taskPresenter;
        private LawnTaskBarFactory _taskBarFactory;

        public override Task Model => _task;

        public override void Init()
        {
            if (enabled)
                return;

            _taskPresenter = GetComponent<LawnTaskPresenter>();
            _taskBarFactory = GetComponent<LawnTaskBarFactory>();
            _task = new LawnTask(Config.TaskAmountWaterToLawn);
            _taskPresenter.Init(_task);
            LawnTaskBarPresenter taskBarPresenter = _taskBarFactory.Create(transform);
            taskBarPresenter.Init(_task);
            enabled = true;
        }
    }
}
