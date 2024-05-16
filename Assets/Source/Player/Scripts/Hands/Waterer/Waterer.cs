using Unity.VisualScripting;

namespace Nevalyashka.Brigade.Model
{
    public class Waterer : Hands<LawnTask>
    {
        private Dragger _dragger;

        private WateringCanLiftable WateringCanLiftable => _dragger.CurrentObject as WateringCanLiftable;
        private WateringCan WateringCan => WateringCanLiftable != null ? WateringCanLiftable.Model : null;

        public Waterer(PlayerRouter playerRouter, Dragger dragger) : base(playerRouter)
        {
            _dragger = dragger;
        }

        public override void SetObject(LawnTask targetObject)
        {
            if (WateringCan == null)
                return;

            if (TargetObject != null)
                return;

            TargetObject = targetObject;
            TargetObject.Select();
        }

        public override void Cancel()
        {
            if (TargetObject == null)
                return;

            TargetObject.Cancel();
            TargetObject = null;
        }

        protected override void OnUsing()
        {
            if (WateringCan == null)
                return;

            if (TargetObject == null)
                return;

            if (WateringCan.HasWater == false)
                return;

            WateringCan.Water(TargetObject.TargetAmount, out int amount);
            TargetObject.TryDo<Null>(amount);
        }
    }
}
