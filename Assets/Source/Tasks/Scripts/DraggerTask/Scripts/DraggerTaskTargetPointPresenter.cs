using Nevalyashka.Brigade.Model;
using Unity.VisualScripting;
using UnityEngine;

namespace Nevalyashka.Brigade.Presenter
{
    public class DraggerTaskTargetPointPresenter : Presenter<DraggerTaskTargetPoint>
    {
        private bool _isCompleted;

        private void OnTriggerStay(Collider other)
        {
            if (_isCompleted)
                return;

            LiftablePresenter liftablePresenter;

            if (other.TryGetComponent(out liftablePresenter) == false)
                return;

            liftablePresenter.TryGetComponent(out ObjectBorderPresenter objectBorderPresenter);

            if (other.TryGetComponent(out Presenter<DraggerTask> taskPresenter))
            {
                if (Model.Type == taskPresenter.Model.Type)
                {
                    if (liftablePresenter.Model.IsDragged == false)
                    {
                        objectBorderPresenter.Cancel();

                        if (taskPresenter.TryGetComponent(out Rigidbody rigidbody))
                            rigidbody.isKinematic = true;

                        taskPresenter.Model.TryDo<Null>(1);
                        taskPresenter.transform.position = transform.position;
                        taskPresenter.transform.eulerAngles = Vector3.zero;
                        taskPresenter.transform.SetParent(transform);
                        _isCompleted = true;
                        Destroy(this);
                    }
                }
            }
        }
    }
}
