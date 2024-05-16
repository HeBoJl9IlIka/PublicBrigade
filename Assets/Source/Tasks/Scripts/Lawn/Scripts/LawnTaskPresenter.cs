using Nevalyashka.Brigade.Model;
using System.Collections.Generic;
using UnityEngine;

namespace Nevalyashka.Brigade.Presenter
{
    public class LawnTaskPresenter : TaskPresenter<LawnTask>
    {
        [SerializeField] private Material _targetMaterial;

        private MeshRenderer _meshRenderer;
        private Material _defaultMaterial;

        protected override void ExecuteByAwake()
        {
            _meshRenderer = GetComponent<MeshRenderer>();
            _defaultMaterial = _meshRenderer.material;
        }

        protected override void ExecuteByCompleted()
        {
            ChangeMaterial(_targetMaterial);
        }

        protected override void ShowTarget()
        {
            ChangeMaterial(_targetMaterial);
        }

        protected override void HideTarget()
        {
            ChangeMaterial(_defaultMaterial);
        }

        private void ChangeMaterial(Material material)
        {
            List<Material> materials = new List<Material>
            {
                material
            };

            _meshRenderer.SetMaterials(materials);
        }
    }
}
