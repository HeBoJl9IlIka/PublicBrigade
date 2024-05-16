using Nevalyashka.Brigade.Model;

namespace Nevalyashka.Brigade.Root
{
    public abstract class TaskRoot : Root
    {
        public abstract Task Model { get; }

        public abstract void Init();

        private void OnEnable()
        {
        }

        private void OnDisable()
        {
        }
    }
}
