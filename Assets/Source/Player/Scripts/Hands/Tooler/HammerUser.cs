using Unity.VisualScripting;

namespace Nevalyashka.Brigade.Model
{
    public class HammerUser : Hands<HammerTask>
    {
        private Dragger _dragger;

        private HammerLiftable ModelLiftable => _dragger.CurrentObject as HammerLiftable;
        private Hammer Model => ModelLiftable != null ? ModelLiftable.Model : null;

        public HammerUser(PlayerRouter playerRouter, Dragger dragger) : base(playerRouter)
        {
            _dragger = dragger;
        }

        public override void SetObject(HammerTask targetObject)
        {
            if (ModelLiftable == null)
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
            if (ModelLiftable == null)
                return;

            if (TargetObject == null)
                return;

            TargetObject.TryDo<Null>(Model.Amount);
        }
    }
}
