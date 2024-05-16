using UnityEngine;

namespace Nevalyashka.Brigade.Presenter
{
    public class ObjectInspectorPresenter : MonoBehaviour
    {
        [SerializeField] private LayerMask _layers;
        [SerializeField] private float _sphereOffset = 0.5f;
        [SerializeField] private float _radius = 1;

        private Collider[] _newObjects;

        public bool TryGetObjects<T>(out T obj)
        {
            obj = default;
            Collider newObject = null;
            float distance = 0;
            Vector3 spherePosition = new Vector3(transform.localPosition.x, transform.localPosition.y + _sphereOffset, transform.localPosition.z);
            Vector3 sphereOffsetForward = (transform.forward * _sphereOffset);
            _newObjects = Physics.OverlapSphere(spherePosition + sphereOffsetForward, _radius, _layers, QueryTriggerInteraction.Collide);

            if (_newObjects.Length != 0)
            {
                distance = Vector3.Distance(transform.position, _newObjects[0].transform.position);
                newObject = _newObjects[0];

                foreach (Collider collider in _newObjects)
                {
                    float currentDistance = Vector3.Distance(transform.position, collider.transform.position);

                    if (currentDistance < distance)
                    {
                        newObject = collider;
                        distance = currentDistance;
                    }
                }

                newObject.TryGetComponent(out obj);
            }

            return obj != null;
        }

        private void OnDrawGizmosSelected()
        {
            if (_newObjects == null)
                return;

            Color transparentGreen = new Color(0.0f, 1.0f, 0.0f, 0.35f);
            Color transparentRed = new Color(1.0f, 0.0f, 0.0f, 0.35f);

            if (_newObjects.Length != 0)
                Gizmos.color = transparentGreen;
            else
                Gizmos.color = transparentRed;

            Vector3 spherePosition = new Vector3(transform.localPosition.x, transform.localPosition.y + _sphereOffset, transform.localPosition.z);
            Vector3 sphereOffsetForward = (transform.forward * _sphereOffset);
            Gizmos.DrawSphere(spherePosition + sphereOffsetForward, _radius);
        }
    }
}
