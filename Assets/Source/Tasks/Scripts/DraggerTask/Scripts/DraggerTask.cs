namespace Nevalyashka.Brigade.Model
{
    public class DraggerTask : Task
    {
        private Liftable _liftable;

        public Config.DraggerTaskType Type { get; private set; }

        public DraggerTask(int targetAmount, Config.DraggerTaskType type) : base(targetAmount)
        {
            Type = type;
        }

        protected override void ExecuteByTryDo()
        {
            
        }

        public void SetLiftable(Liftable liftable)
        {
            _liftable = liftable;
        }
    }
}
