using Nevalyashka.Brigade.Model;
using UnityEngine;

namespace Nevalyashka.Brigade.Presenter
{
    [RequireComponent(typeof(ObjectInspectorPresenter))]
    public class SprinklerInspectorPresenter : Presenter<Sprinkler>
    {
        private ObjectInspectorPresenter _objectInspector;

        private void Awake()
        {
            _objectInspector = GetComponent<ObjectInspectorPresenter>();
        }

        private void LateUpdate()
        {
            if (_objectInspector.TryGetObjects(out BucketPresenter bucket))
                Model.SetObject(bucket.Model);
            else
                Model.Cancel();
        }
    }
}
