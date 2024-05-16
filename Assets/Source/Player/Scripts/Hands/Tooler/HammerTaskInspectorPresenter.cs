using Nevalyashka.Brigade.Model;
using UnityEngine;

namespace Nevalyashka.Brigade.Presenter
{
    [RequireComponent(typeof(ObjectInspectorPresenter))]
    public class HammerTaskInspectorPresenter : Presenter<HammerUser>
    {
        private ObjectInspectorPresenter _objectInspector;

        private void Awake()
        {
            _objectInspector = GetComponent<ObjectInspectorPresenter>();
        }

        private void LateUpdate()
        {
            if (_objectInspector.TryGetObjects(out HammerTaskPresenter hammerTask))
                Model.SetObject(hammerTask.Model);
            else
                Model.Cancel();
        }
    }
}
