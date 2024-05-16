using Nevalyashka.Brigade.Model;
using UnityEngine;

namespace Nevalyashka.Brigade.Presenter
{
    public class DraggerTaskPresenter : TaskPresenter<DraggerTask>
    {
        private GameObject _clone;

        public void SetClone(GameObject clone)
        {
            _clone = clone;
        }

        protected override void ExecuteByAwake()
        {
            
        }

        protected override void ExecuteByCompleted()
        {
            
        }

        protected override void HideTarget()
        {
            _clone.SetActive(false);
        }

        protected override void ShowTarget()
        {
            _clone.SetActive(true);
        }
    }
}
