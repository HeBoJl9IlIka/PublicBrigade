namespace Nevalyashka.Brigade.Model
{
    public class Giver : Hands<Bucket>
    {
        private Inventory _inventory;

        public Giver(PlayerRouter playerRouter, Inventory inventory) : base(playerRouter)
        {
            _inventory = inventory;
        }

        public override void SetObject(Bucket targetObject)
        {
            if (TargetObject != null)
                return;

            TargetObject = targetObject;
        }

        public override void Cancel()
        {
            if (TargetObject != null)
                TargetObject = null;
        }

        protected override void OnUsing()
        {
            if (TargetObject == null)
                return;

            if (TargetObject.CanAddMaterial(_inventory.TypeMaterial))
            {
                if (_inventory.TryRemoveMaterial(TargetObject.EmptyAmount, out ConstructionMaterial material, out int gettingAmount))
                    TargetObject.AddMaterial(material, gettingAmount);
            }
            else if (_inventory.CanAddMaterial(TargetObject.TypeMaterial))
            {
                if (TargetObject.TryRemoveMaterial(_inventory.EmptyAmount, out ConstructionMaterial material1, out int gettingAmount1))
                    _inventory.AddMaterial(material1, gettingAmount1);
            }
        }
    }
}
