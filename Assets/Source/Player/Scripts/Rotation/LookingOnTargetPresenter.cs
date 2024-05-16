using UnityEngine;

namespace Nevalyashka.Brigade.Presenter
{
    public class LookingOnTargetPresenter : MonoBehaviour
    {
        private void LateUpdate()
        {
            if (gameObject.TryGetComponent(out HingeJoint hingeJoint) == false)
                return;

            Rigidbody rigidbody = hingeJoint.connectedBody;
            Vector3 direction = rigidbody.transform.position - transform.position;
            direction = new Vector3(direction.x, 0, direction.z);
            transform.rotation = Quaternion.LookRotation(direction, Vector3.up);
        }
    }
}
