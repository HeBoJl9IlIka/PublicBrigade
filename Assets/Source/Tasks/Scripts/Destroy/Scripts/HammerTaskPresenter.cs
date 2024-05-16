using Nevalyashka.Brigade.Model;
using UnityEngine;

namespace Nevalyashka.Brigade.Presenter
{
    [RequireComponent(typeof(MeshRenderer))]
    public class HammerTaskPresenter : TaskPresenter<HammerTask>
    {
        private MeshRenderer _meshRenderer;

        protected override void ExecuteByAwake()
        {
            _meshRenderer = GetComponent<MeshRenderer>();
        }

        protected override void ExecuteByCompleted()
        {
            gameObject.SetActive(false);
        }

        protected override void ShowTarget()
        {
            _meshRenderer.enabled = false;
        }

        protected override void HideTarget()
        {
            _meshRenderer.enabled = true;
        }
    }
}
