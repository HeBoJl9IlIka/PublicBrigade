using Nevalyashka.Brigade.Model;
using UnityEngine;

namespace Nevalyashka.Brigade.Presenter
{
    [RequireComponent(typeof(BoxCollider))]
    public class DraggerPresenter : Presenter<Dragger>
    {
        private BoxCollider _boxCollider;
        private LayerMask _defaultLayerMask;
        private RotationPresenter _rotationPresenter;

        private void Awake()
        {
            _defaultLayerMask = gameObject.layer;
            _boxCollider = GetComponent<BoxCollider>();
            _rotationPresenter = GetComponent<RotationPresenter>();
        }

        private void OnEnable()
        {
            Model.Dragging += OnDragging;
            Model.Dropping += OnDropping;
        }

        private void OnDisable()
        {
            Model.Dragging -= OnDragging;
            Model.Dropping -= OnDropping;
        }

        private void OnDragging(bool isEasy)
        {
            if (isEasy)
                _boxCollider.enabled = true;
            else
                _rotationPresenter.enabled = false;

            gameObject.layer = Config.CharacterNumberTargetLayerMask;
        }

        private void OnDropping(bool isEasy)
        {
            if (isEasy)
                _boxCollider.enabled = false;
            else
                _rotationPresenter.enabled = true;

            gameObject.layer = _defaultLayerMask;
        }
    }
}
