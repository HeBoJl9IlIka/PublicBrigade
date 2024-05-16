using DG.Tweening;
using Nevalyashka.Brigade.Model;
using UnityEngine;
using UnityEngine.UI;

namespace Nevalyashka.Brigade.Presenter
{
    public abstract class AmountBarPresenter<T> : Presenter<T>
    {
        public abstract int MaxAmount { get; }

        private Camera _camera;
        private Slider _slider;

        private void Start()
        {
            _camera = Camera.main;
            _slider = GetComponentInChildren<Slider>(true);

            _slider.gameObject.SetActive(false);
            _slider.maxValue = MaxAmount;
            _slider.value = 0;
        }

        private void LateUpdate()
        {
            Vector3 direction = _camera.transform.position - transform.position;
            transform.rotation = Quaternion.LookRotation(direction);
        }

        protected void OnChanged(int amount)
        {
            _slider.DOValue(amount, Config.DurationMaterialBar);
            _slider.gameObject.SetActive(amount > 0);
        }
    }
}
