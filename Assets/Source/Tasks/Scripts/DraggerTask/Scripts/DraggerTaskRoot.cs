using Nevalyashka.Brigade.Model;
using Nevalyashka.Brigade.Presenter;
using UnityEngine;

namespace Nevalyashka.Brigade.Root
{
    [RequireComponent(typeof(DraggerTaskPresenter))]
    public class DraggerTaskRoot : TaskRoot
    {
        [SerializeField] private DraggerTaskTargetPointPresenter _targetPointPresenter;
        [SerializeField] private Config.DraggerTaskType _type;

        private DraggerTask _task;
        private DraggerTaskPresenter _taskPresenter;
        private DraggerTaskTargetPoint _targetPoint;
        private DraggerTaskPresenter _clone;

        public override Task Model => _task;

        public override void Init()
        {
            _taskPresenter = GetComponent<DraggerTaskPresenter>();

            _task = new DraggerTask(1, _type);
            _targetPoint = new DraggerTaskTargetPoint(_type);
            GameObject clone = CreateClone();

            _taskPresenter.Init(_task);
            _taskPresenter.SetClone(clone);
            _targetPointPresenter.Init(_targetPoint);
        }

        private GameObject CreateClone()
        {
            _clone = Instantiate(_taskPresenter, Vector3.down * 10, Quaternion.identity);
            _clone.gameObject.SetActive(false);
            MonoBehaviour[] monoBehaviours = _clone.GetComponents<MonoBehaviour>();
            Rigidbody rigidbody = _clone.GetComponent<Rigidbody>();
            BoxCollider boxCollider = _clone.GetComponent<BoxCollider>();

            foreach (MonoBehaviour monoBehaviour in monoBehaviours)
                Destroy(monoBehaviour);

            Destroy(rigidbody);
            Destroy(boxCollider);
            _clone.transform.SetParent(_targetPointPresenter.transform);
            _clone.transform.localPosition = Vector3.zero;
            _clone.transform.localEulerAngles = Vector3.zero;

            return _clone.gameObject;
        }
    }
}
