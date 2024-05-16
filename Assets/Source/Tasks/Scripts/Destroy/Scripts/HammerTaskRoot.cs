using Nevalyashka.Brigade.Factory;
using Nevalyashka.Brigade.Model;
using Nevalyashka.Brigade.Presenter;
using UnityEngine;

namespace Nevalyashka.Brigade.Root
{
    [RequireComponent(typeof(HammerTaskPresenter))]
    [RequireComponent(typeof(HammerTaskBarFactory))]
    public class HammerTaskRoot : TaskRoot
    {
        private HammerTask _task;
        private HammerTaskPresenter _taskPresenter;
        private HammerTaskBarFactory _taskBarFactory;

        public override Task Model => _task;

        public override void Init()
        {
            if (enabled)
                return;

            _taskPresenter = GetComponent<HammerTaskPresenter>();
            _taskBarFactory = GetComponent<HammerTaskBarFactory>();
            _task = new HammerTask(Config.TaskAmountDestroy);
            _taskPresenter.Init(_task);
            HammerTaskBarPresenter taskBarPresenter = _taskBarFactory.Create(transform);
            taskBarPresenter.Init(_task);
            enabled = true;
        }
    }
}
