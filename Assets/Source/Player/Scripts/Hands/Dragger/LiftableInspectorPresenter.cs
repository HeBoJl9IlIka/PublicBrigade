using Nevalyashka.Brigade.Model;
using UnityEngine;

namespace Nevalyashka.Brigade.Presenter
{
    [RequireComponent(typeof(ObjectInspectorPresenter))]
    public class LiftableInspectorPresenter : Presenter<Dragger>
    {
        private ObjectInspectorPresenter _objectInspector;

        private void Awake()
        {
            _objectInspector = GetComponent<ObjectInspectorPresenter>();
        }

        private void LateUpdate()
        {
            if (_objectInspector.TryGetObjects(out LiftablePresenter liftable))
                Model.SetObject(liftable.Model);
            else
                Model.Cancel();
        }
    }
}
