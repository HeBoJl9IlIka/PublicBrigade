using Nevalyashka.Brigade.Model;
using UnityEngine;

namespace Nevalyashka.Brigade.Presenter
{
    [RequireComponent(typeof(Animator))]
    public class AnimatorPresenter : Presenter<AnimatorModel>
    {
        private Animator _animator;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        private void OnEnable()
        {
            Model.Moving += OnMoving;
            Model.Dragging += OnDragging;
            Model.Dropping += OnDropping;
        }

        private void OnDisable()
        {
            Model.Moving -= OnMoving;
            Model.Dragging -= OnDragging;
            Model.Dropping -= OnDropping;
        }

        private void OnMoving(Vector2 direction)
        {
            _animator.SetFloat(Config.AnimatorSpeed, direction.magnitude);

            float directionAngle = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg;
            float playerAngle = Mathf.Atan2(transform.forward.x, transform.forward.z) * Mathf.Rad2Deg;
            float targetAngle = playerAngle - directionAngle;
            _animator.SetFloat(Config.AnimatorAngle, targetAngle);
        }

        private void OnDragging(bool isEasy)
        {
            _animator.SetBool(Config.AnimatorIsDraggingHeavy, isEasy == false);

            if (isEasy)
            {
                _animator.SetLayerWeight(Config.AnimatorLayerEasy, 1);
            }
            else
            {
                _animator.SetLayerWeight(Config.AnimatorLayerHeavy, 1);
            }
        }

        private void OnDropping(bool isEasy)
        {
            _animator.SetBool(Config.AnimatorIsDraggingHeavy, false);

            if (isEasy)
            {
                _animator.SetLayerWeight(Config.AnimatorLayerEasy, 0);
            }
            else
            {
                _animator.SetLayerWeight(Config.AnimatorLayerHeavy, 0);
            }
        }
    }
}
