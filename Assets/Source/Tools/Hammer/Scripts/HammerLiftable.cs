namespace Nevalyashka.Brigade.Model
{
    public class HammerLiftable : Liftable
    {
        public Hammer Model { get; private set; }

        public HammerLiftable(bool isEasy, Hammer model) : base(isEasy)
        {
            Model = model;
        }
    }
}
