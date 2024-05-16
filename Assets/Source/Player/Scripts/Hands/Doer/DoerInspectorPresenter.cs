using Nevalyashka.Brigade.Model;
using UnityEngine;

namespace Nevalyashka.Brigade.Presenter
{
    [RequireComponent(typeof(ObjectInspectorPresenter))]
    public class DoerInspectorPresenter : Presenter<Doer>
    {
        private ObjectInspectorPresenter _objectInspector;

        private void Awake()
        {
            _objectInspector = GetComponent<ObjectInspectorPresenter>();
        }

        private void LateUpdate()
        {
            if (_objectInspector.TryGetObjects(out ConstructionMaterialTaskPresenter obj))
                Model.SetObject(obj.Model);
            else
                Model.Cancel();
        }
    }
}
