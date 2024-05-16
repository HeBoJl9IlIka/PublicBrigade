using Nevalyashka.Brigade.Model;
using UnityEngine;

namespace Nevalyashka.Brigade.Presenter
{
    [RequireComponent(typeof(ObjectBorderPresenter))]
    public abstract class TaskPresenter<T> : Presenter<T> where T : Task
    {
        private ObjectBorderPresenter _materialChanger;

        private void Awake()
        {
            _materialChanger = GetComponent<ObjectBorderPresenter>();
            ExecuteByAwake();
        }

        private void OnEnable()
        {
            Model.Enabled += OnEnabled;
            Model.Disabled += OnDisabled;
            Model.Selected += OnSelected;
            Model.Canceled += OnCanceled;
            Model.Completed += OnCompleted;
            Model.ShowingTarget += OnShowingTarget;
            Model.HidingTarget += OnHidingTarget;
            Model.LayerChanged += OnLayerChanged;
        }

        private void OnDisable()
        {
            Model.Enabled -= OnEnabled;
            Model.Disabled -= OnDisabled;
            Model.Selected -= OnSelected;
            Model.Canceled -= OnCanceled;
            Model.Completed -= OnCompleted;
            Model.ShowingTarget -= OnShowingTarget;
            //Model.HidingTarget -= OnHidingTarget;
            Model.LayerChanged -= OnLayerChanged;
        }

        protected abstract void ExecuteByAwake();
        protected abstract void ExecuteByCompleted();
        protected abstract void ShowTarget();
        protected abstract void HideTarget();

        private void OnEnabled() => gameObject.SetActive(true);
        private void OnDisabled() => gameObject.SetActive(false);
        private void OnSelected() => _materialChanger.Select();
        private void OnCanceled() => _materialChanger.Cancel();
        private void OnShowingTarget() => ShowTarget();
        private void OnHidingTarget() => HideTarget();

        private void OnLayerChanged(int number)
        {
            gameObject.layer = number;
        }

        private void OnCompleted()
        {
            gameObject.layer = Config.LayerNumberCompletedTask;
            _materialChanger.enabled = false;
            ExecuteByCompleted();
        }
    }
}
