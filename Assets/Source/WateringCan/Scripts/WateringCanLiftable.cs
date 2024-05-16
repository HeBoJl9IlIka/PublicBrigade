namespace Nevalyashka.Brigade.Model
{
    public class WateringCanLiftable : Liftable
    {
        public WateringCan Model { get; private set; }

        public WateringCanLiftable(bool isEasy, WateringCan wateringCan) : base(isEasy)
        {
            Model = wateringCan;
        }
    }
}
