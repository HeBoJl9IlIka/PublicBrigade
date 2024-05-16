namespace Nevalyashka.Brigade.Model
{
    public class Doer : Hands<ConstructionMaterialTask>
    {
        private Inventory _inventory;

        public Doer(PlayerRouter playerRouter, Inventory inventory) : base(playerRouter)
        {
            _inventory = inventory;
        }

        public override void SetObject(ConstructionMaterialTask targetObject)
        {
            if (TargetObject != null)
                return;

            if (targetObject.TargetMaterial != _inventory.TypeMaterial)
                return;

            if (targetObject.TargetAmount == 0)
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

            if (TargetObject.TargetMaterial != _inventory.TypeMaterial)
                return;

            if (_inventory.TryRemoveMaterial(TargetObject.TargetAmount, out ConstructionMaterial material, out int gettingAmount))
                TargetObject.TryDo(gettingAmount, material);

            if (TargetObject.TargetAmount == 0)
                Cancel();
        }
    }
}
