using Nevalyashka.Brigade.Model;
using Nevalyashka.Brigade.Presenter;
using UnityEngine;

namespace Nevalyashka.Brigade.Root
{
    [RequireComponent(typeof(ConstructionMaterialPresenter))]
    public class ConstructionMaterialRoot : Root
    {
        [SerializeField] private Config.TypeConstructionMaterial _type;
        [SerializeField] private int _amount;

        private ConstructionMaterial _constructionMaterial;
        private ConstructionMaterialPresenter _constructionMaterialPresenter;

        public override void Compose()
        {
            _constructionMaterialPresenter = GetComponent<ConstructionMaterialPresenter>();
            _constructionMaterial = new ConstructionMaterial(_type, _amount);
            _constructionMaterialPresenter.Init(_constructionMaterial);
        }
    }
}
