namespace Nevalyashka.Brigade.Model
{
    public class Taker : Hands<ConstructionMaterial>
    {
        private Inventory _inventory;

        public Taker(PlayerRouter playerRouter, Inventory inventory) : base(playerRouter)
        {
            _inventory = inventory;
        }

        public override void SetObject(ConstructionMaterial targetObject)
        {
            if (TargetObject != null)
                TargetObject.Cancel();

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

            _inventory.AddMaterial(TargetObject);
        }

        protected override void OnDraggingDropping()
        {
            _inventory.TryRemoveMaterial(Config.MaxAmountInventory, out ConstructionMaterial material, out int gettingAmount);
        }
    }
}
