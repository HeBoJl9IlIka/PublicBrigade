using Nevalyashka.Brigade.Model;
using Nevalyashka.Brigade.Presenter;
using UnityEngine;

namespace Nevalyashka.Brigade.Root
{
    [RequireComponent(typeof(ConstructionMaterialPackagePresenter))]
    public class ConstructionMaterialPackageRoot : Root
    {
        [SerializeField] private Config.TypeConstructionMaterial _type;

        private ConstructionMaterialPackage _constructionMaterial;
        private ConstructionMaterialPackagePresenter _constructionMaterialPresenter;

        public override void Compose()
        {
            _constructionMaterialPresenter = GetComponent<ConstructionMaterialPackagePresenter>();
            _constructionMaterial = new ConstructionMaterialPackage(_type, 0);
            _constructionMaterialPresenter.Init(_constructionMaterial);
        }
    }
}
