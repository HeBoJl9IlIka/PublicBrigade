using Nevalyashka.Brigade.Model;
using UnityEngine;

namespace Nevalyashka.Brigade.Presenter
{
    [RequireComponent(typeof(Rigidbody))]
    public class MovementPresenter : Presenter<Movement>
    {
        private Rigidbody _rigidbody;

        public float Velocity => _rigidbody.velocity.magnitude;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        private void FixedUpdate()
        {
            if (_rigidbody.velocity.magnitude <= Model.MaxSpeed)
            {
                Vector3 direction = new Vector3(Model.Direction.normalized.x, 0, Model.Direction.normalized.y);
                _rigidbody.AddForce(direction * Config.CharacterSpeed, ForceMode.VelocityChange);
            }

            Vector3 velocity = new Vector3(_rigidbody.velocity.x, 0, _rigidbody.velocity.y);
            Model.SetCharacterVelocity(velocity);
        }
    }
}
