using Nevalyashka.Brigade.Model;
using UnityEngine;

namespace Nevalyashka.Brigade.Presenter
{
    public class MultiTaskLawnPresenter : MultiTaskPresenter
    {
        [SerializeField] private TaskPresenter<LawnTask> _task;

        public override Task Model => _task.Model;
    }
}
