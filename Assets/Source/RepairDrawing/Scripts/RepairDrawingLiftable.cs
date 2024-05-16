namespace Nevalyashka.Brigade.Model
{
    public class RepairDrawingLiftable : Liftable
    {
        public RepairDrawing Model { get; private set; }

        public RepairDrawingLiftable(bool isEasy, RepairDrawing model) : base(isEasy)
        {
            Model = model;
        }
    }
}
