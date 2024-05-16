using UnityEngine;

namespace Nevalyashka.Brigade.Presenter
{
    [RequireComponent(typeof(MeshRenderer))]
    [RequireComponent(typeof(BoxCollider))]
    public class ConstructionTaskPresenter : ConstructionMaterialTaskPresenter
    {
        private BoxCollider _boxCollider;

        protected override void ExecuteByAwake()
        {
            MeshRenderer = GetComponent<MeshRenderer>();
            _boxCollider = GetComponent<BoxCollider>();
            DefaultMaterial = MeshRenderer.material;
        }

        protected override void ExecuteByCompleted()
        {
            ChangeMaterial(TargetMaterial);
            _boxCollider.isTrigger = false;
        }

        protected override void ShowTarget()
        {
            ChangeMaterial(TargetMaterial);
        }

        protected override void HideTarget()
        {
            ChangeMaterial(DefaultMaterial);
        }
    }
}
