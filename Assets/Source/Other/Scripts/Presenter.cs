using UnityEngine;

namespace Nevalyashka.Brigade.Presenter
{
    public abstract class Presenter<T> : MonoBehaviour
    {
        public T Model { get; protected set; }

        public void Init(T model)
        {
            Model = model;
            enabled = true;
        }
    }
}
