using DG.Tweening;
using Nevalyashka.Brigade.Model;
using UnityEngine;

namespace Nevalyashka.Brigade.Presenter
{
    public class RotationPresenter : Presenter<Movement>
    {
        private Vector3 _lastPosition;

        private void Start()
        {
            _lastPosition = transform.position;
        }

        private void Update()
        {
            if (transform.position == _lastPosition)
                return;

            if (Model.Direction == Vector2.zero)
                return;

            float angle = Mathf.Atan2(Model.Direction.x, Model.Direction.y) * Mathf.Rad2Deg;
            transform.DORotate(new Vector3(0, angle, 0), Config.CharacterDurationRotation);
            _lastPosition = transform.position;
        }
    }
}
