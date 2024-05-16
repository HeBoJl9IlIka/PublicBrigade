using Nevalyashka.Brigade.Model;
using UnityEngine;

namespace Nevalyashka.Brigade.Presenter
{
    public class MultiTaskConstructionPresenter : MultiTaskPresenter
    {
        [SerializeField] private TaskPresenter<ConstructionMaterialTask> _task;

        public override Task Model => _task.Model;
    }
}
