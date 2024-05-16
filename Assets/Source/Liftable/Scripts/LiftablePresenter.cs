using DG.Tweening;
using Nevalyashka.Brigade.Model;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace Nevalyashka.Brigade.Presenter
{
    [RequireComponent(typeof(ObjectBorderPresenter))]
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(Collider))]
    public class LiftablePresenter : Presenter<Liftable>
    {
        private ObjectBorderPresenter _materialChanger;
        private Rigidbody _rigidbody;
        private ContainerLiftablesPresenter _parent;
        private LayerMask _defaultLayerMask;
        private Collider _collider;
        private Dictionary<DraggerPresenter, HingeJoint> _hingesJoints = new Dictionary<DraggerPresenter, HingeJoint>();
        private Tween _tween;

        public bool IsEasy => Model.IsEasy;

        private void Awake()
        {
            _parent = GetComponentInParent<ContainerLiftablesPresenter>();
            _materialChanger = GetComponent<ObjectBorderPresenter>();
            _rigidbody = GetComponent<Rigidbody>();
            _defaultLayerMask = gameObject.layer;
            _collider = GetComponent<Collider>();
        }

        private void OnEnable()
        {
            Model.Selected += OnSelected;
            Model.Canceled += OnCanceled;
            Model.Dragging += OnDragging;
            Model.Dropped += OnDropped;
            Model.Throwed += OnThrowed;
        }

        private void OnDisable()
        {
            Model.Selected -= OnSelected;
            Model.Canceled -= OnCanceled;
            Model.Dragging -= OnDragging;
            Model.Dropped -= OnDropped;
            Model.Throwed -= OnThrowed;
        }

        private void OnSelected() => _materialChanger.Select();

        private void OnCanceled() => _materialChanger.Cancel();

        private void OnDragging(Transform point)
        {
            if (IsEasy)
                DragEasyObject(point);
            else
                DragHeavyObject(point);
        }

        private void OnDropped(Transform point)
        {
            if (IsEasy)
                DropEasyObject();
            else
                DropHeavyObject(point);
        }

        private void DragEasyObject(Transform point)
        {
            _rigidbody.isKinematic = true;
            transform.SetParent(point);
            _tween = transform.DOLocalMove(Vector3.zero, Config.DurationDragEasyObject);
            transform.localEulerAngles = Vector3.zero;
            _collider.enabled = false;
            gameObject.layer = Config.LiftableNumberTargetLayerMask;
        }

        private void DropEasyObject()
        {
            if (_tween != null)
                _tween.Kill();

            transform.SetParent(_parent.transform);
            _rigidbody.isKinematic = false;
            _collider.enabled = true;
            gameObject.layer = _defaultLayerMask;
        }

        private void DragHeavyObject(Transform point)
        {
            HingeJoint hingeJoint = null;
            DraggerPresenter draggerPresenter = point.GetComponentInParent<DraggerPresenter>(true);

            if (_hingesJoints.ContainsKey(draggerPresenter) == false)
            {
                hingeJoint = draggerPresenter.AddComponent<HingeJoint>();
                hingeJoint.axis = Vector3.up;
                hingeJoint.connectedBody = _rigidbody;
                _hingesJoints.Add(draggerPresenter, hingeJoint);
            }
        }

        private void DropHeavyObject(Transform point)
        {
            HingeJoint hingeJoint = null;
            DraggerPresenter draggerPresenter = point.GetComponentInParent<DraggerPresenter>(true);

            if (_hingesJoints.ContainsKey(draggerPresenter))
            {
                draggerPresenter.TryGetComponent(out hingeJoint);
                Destroy(hingeJoint);
                _hingesJoints.Remove(draggerPresenter);
            }
        }

        private void OnThrowed(Transform point)
        {
            DropEasyObject();
            _rigidbody.AddForce(point.transform.forward * Config.ThrowingPower, ForceMode.VelocityChange);
        }
    }
}
