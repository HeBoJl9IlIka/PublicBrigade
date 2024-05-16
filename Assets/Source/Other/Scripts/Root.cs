using UnityEngine;

namespace Nevalyashka.Brigade.Root
{
    public abstract class Root : MonoBehaviour
    {
        private void Awake() => Compose();
        public virtual void Compose() { }
    }
}
