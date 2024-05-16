namespace Nevalyashka.Brigade.Model
{
    public class ConstructionTask : ConstructionMaterialTask
    {
        public ConstructionTask(int targetAmount, Config.TypeConstructionMaterial targetMaterial) : base(targetAmount, targetMaterial)
        {
        }
    }
}
