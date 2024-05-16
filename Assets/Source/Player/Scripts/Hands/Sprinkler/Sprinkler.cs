namespace Nevalyashka.Brigade.Model
{
    public class Sprinkler : Hands<Bucket>
    {
        private Dragger _dragger;

        private ConstructionMaterialPackageLiftable PackageLiftable => _dragger.CurrentObject as ConstructionMaterialPackageLiftable;
        private ConstructionMaterialPackage ConstructionMaterialPackage => PackageLiftable != null ? PackageLiftable.Model : null;

        public bool IsDragging => ConstructionMaterialPackage != null;

        public Sprinkler(PlayerRouter playerRouter, Dragger dragger) : base(playerRouter)
        {
            _dragger = dragger;
        }

        public override void SetObject(Bucket targetObject)
        {
            if (ConstructionMaterialPackage == null)
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
            if (TargetObject == null)
                return;

            if (ConstructionMaterialPackage == null)
                return;

            if (TargetObject.CanAddMaterial(ConstructionMaterialPackage.Type))
                TargetObject.AddMaterial(ConstructionMaterialPackage, Config.MaxAmountBucket);
        }
    }
}
