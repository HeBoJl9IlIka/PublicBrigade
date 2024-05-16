namespace Nevalyashka.Brigade.Model
{
    public class DraggerTaskTargetPoint
    {
        public Config.DraggerTaskType Type { get; private set; }

        public DraggerTaskTargetPoint(Config.DraggerTaskType type)
        {
            Type = type;
        }
    }
}
