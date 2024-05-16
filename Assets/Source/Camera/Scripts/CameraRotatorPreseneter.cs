using DG.Tweening;
using Nevalyashka.Brigade.Model;
using UnityEngine;

namespace Nevalyashka.Brigade.Presenter
{
    public class CameraRotatorPreseneter : Presenter<CameraRotator>
    {
        private CameraContainerPresenter _containerPresenter;

        private void Awake()
        {
            _containerPresenter = Camera.main.GetComponentInParent<CameraContainerPresenter>();
        }

        private void OnEnable()
        {
            Model.Rotated += OnRotated;
        }

        private void OnDisable()
        {
            Model.Rotated -= OnRotated;
        }

        private void OnRotated(float angle)
        {
            Vector3 rotation = _containerPresenter.transform.eulerAngles;
            rotation = new Vector3(rotation.x, angle, rotation.z);
            _containerPresenter.transform.DORotate(rotation, Config.DurationRotateCamera);
        }
    }
}
