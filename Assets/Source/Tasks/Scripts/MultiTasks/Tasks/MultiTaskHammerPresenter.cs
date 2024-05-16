using Nevalyashka.Brigade.Model;
using UnityEngine;

namespace Nevalyashka.Brigade.Presenter
{
    public class MultiTaskHammerPresenter : MultiTaskPresenter
    {
        [SerializeField] private TaskPresenter<HammerTask> _task;

        public override Task Model => _task.Model;
    }
}