namespace Nevalyashka.Brigade.Model
{
    public interface ISwitchable
    {
        public bool IsEnabled { get; }

        void Enable();
        void Disable();
    }
}
