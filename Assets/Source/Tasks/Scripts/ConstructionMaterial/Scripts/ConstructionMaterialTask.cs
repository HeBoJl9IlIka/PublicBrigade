namespace Nevalyashka.Brigade.Model
{
    public class ConstructionMaterialTask : Task
    {
        public Config.TypeConstructionMaterial TargetMaterial { get; private set; }

        public ConstructionMaterialTask(int targetAmount, Config.TypeConstructionMaterial targetMaterial) : base(targetAmount)
        {
            TargetMaterial = targetMaterial;
        }

        protected override bool CanDo<T>(T material)
        {
            if (material is ConstructionMaterial == false)
                return false;

            ConstructionMaterial constructionMaterial = material as ConstructionMaterial;
            return TargetMaterial == constructionMaterial.Type;
        }
    }
}
