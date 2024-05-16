using Nevalyashka.Brigade.Model;
using System.Collections.Generic;
using UnityEngine;

namespace Nevalyashka.Brigade.Presenter
{
    [RequireComponent(typeof(MeshRenderer))]
    public class ConstructionMaterialTaskPresenter : TaskPresenter<ConstructionMaterialTask>
    {
        [SerializeField] protected Material TargetMaterial;

        protected MeshRenderer MeshRenderer;
        protected Material DefaultMaterial;

        protected override void ExecuteByAwake()
        {
            MeshRenderer = GetComponent<MeshRenderer>();
            DefaultMaterial = MeshRenderer.material;
        }

        protected override void ExecuteByCompleted()
        {
            ChangeMaterial(TargetMaterial);
        }

        protected override void ShowTarget()
        {
            ChangeMaterial(TargetMaterial);
        }

        protected override void HideTarget()
        {
            ChangeMaterial(DefaultMaterial);
        }

        protected void ChangeMaterial(Material material)
        {
            List<Material> materials = new List<Material>
            {
                material
            };

            MeshRenderer.SetMaterials(materials);
        }
    }
}
