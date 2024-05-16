namespace Nevalyashka.Brigade.Model
{
    public class WaterFiller : Hands<Water>
    {
        private Dragger _dragger;

        private WateringCanLiftable WateringCanLiftable => _dragger.CurrentObject as WateringCanLiftable;
        private WateringCan WateringCan => WateringCanLiftable != null ? WateringCanLiftable.Model : null;

        public WaterFiller(PlayerRouter playerRouter, Dragger dragger) : base(playerRouter)
        {
            _dragger = dragger;
        }

        public override void SetObject(Water targetObject)
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

            WateringCan.Fill();
        }
    }
}
