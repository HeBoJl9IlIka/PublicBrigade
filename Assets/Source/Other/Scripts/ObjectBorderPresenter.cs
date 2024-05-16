using System.Collections.Generic;
using UnityEngine;

namespace Nevalyashka.Brigade.Presenter
{
    [RequireComponent(typeof(MeshRenderer))]
    public class ObjectBorderPresenter : MonoBehaviour
    {
        [SerializeField] private Material _targetMaterial;

        private MeshRenderer _meshRenderer;
        private Material _defaultMaterial;
        private bool _isEnabled;

        private void Awake()
        {
            _meshRenderer = GetComponent<MeshRenderer>();
            _defaultMaterial = _meshRenderer.material;
            _isEnabled = true;
        }

        private void OnEnable()
        {
            _isEnabled = true;
        }

        private void OnDisable()
        {
            _isEnabled = false;
        }

        public void Select()
        {
            if (_isEnabled == false)
                return;

            List<Material> materials = new List<Material>
            {
                _defaultMaterial,
                _targetMaterial
            };

            _meshRenderer.SetMaterials(materials);
        }

        public void Cancel()
        {
            if (_isEnabled == false)
                return;

            List<Material> materials = new List<Material>
            {
                _defaultMaterial,
            };

            _meshRenderer.SetMaterials(materials);
        }
    }
}
