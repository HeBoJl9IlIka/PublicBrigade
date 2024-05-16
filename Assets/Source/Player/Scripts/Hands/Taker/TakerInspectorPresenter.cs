using Nevalyashka.Brigade.Model;
using UnityEngine;

namespace Nevalyashka.Brigade.Presenter
{
    [RequireComponent(typeof(ObjectInspectorPresenter))]
    public class TakerInspectorPresenter : Presenter<Taker>
    {
        private ObjectInspectorPresenter _objectInspector;

        private void Awake()
        {
            _objectInspector = GetComponent<ObjectInspectorPresenter>();
        }

        private void LateUpdate()
        {
            if (_objectInspector.TryGetObjects(out ConstructionMaterialPresenter constructionMaterial))
                Model.SetObject(constructionMaterial.Model);
            else
                Model.Cancel();
        }
    }
}
