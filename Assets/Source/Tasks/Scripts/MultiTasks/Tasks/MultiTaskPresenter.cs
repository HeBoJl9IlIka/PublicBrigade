using Nevalyashka.Brigade.Model;
using UnityEngine;

namespace Nevalyashka.Brigade.Presenter
{
    public abstract class MultiTaskPresenter : MonoBehaviour
    {
        public abstract Task Model { get; }
    }
}
