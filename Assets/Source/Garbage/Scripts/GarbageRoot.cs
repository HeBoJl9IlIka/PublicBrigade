using Nevalyashka.Brigade.Model;
using Nevalyashka.Brigade.Presenter;
using UnityEngine;

namespace Nevalyashka.Brigade.Root
{
    [RequireComponent(typeof(GarbagePresenter))]
    public class GarbageRoot : Root
    {
        private Garbage _garbage;
        private GarbagePresenter _garbagePresenter;

        public override void Compose()
        {

        }
    }
}
