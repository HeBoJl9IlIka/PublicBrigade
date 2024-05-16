using Nevalyashka.Brigade.Model;
using UnityEngine;

namespace Nevalyashka.Brigade.Presenter
{
    [RequireComponent(typeof(ObjectBorderPresenter))]
    public class BucketPresenter : Presenter<Bucket>
    {
        private ObjectBorderPresenter _materialChanger;

        private void Awake()
        {
            _materialChanger = GetComponent<ObjectBorderPresenter>();
        }

        private void OnEnable()
        {
            Model.Selected += OnSelected;
            Model.Canceled += OnCanceled;
        }

        private void OnDisable()
        {
            Model.Selected -= OnSelected;
            Model.Canceled -= OnCanceled;
        }

        private void OnSelected() => _materialChanger.Select();
        private void OnCanceled() => _materialChanger.Cancel();
    }
}
