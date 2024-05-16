namespace Nevalyashka.Brigade.Model
{
    public class ConstructionMaterial
    {
        public Config.TypeConstructionMaterial Type { get; private set; }
        public int Amount { get; private set; }

        public ConstructionMaterial(Config.TypeConstructionMaterial type, int amount)
        {
            Type = type;
            Amount = amount;
        }

        public void Select()
        {
            
        }

        public void Cancel()
        {
            
        }
    }
}
