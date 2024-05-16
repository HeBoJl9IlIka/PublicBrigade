namespace Nevalyashka.Brigade.Model
{
    public class ConstructionMaterialPackageLiftable : Liftable
    {
        public ConstructionMaterialPackage Model { get; private set; }

        public ConstructionMaterialPackageLiftable(bool isEasy, ConstructionMaterialPackage constructionMaterialPackage = null) : base(isEasy)
        {
            Model = constructionMaterialPackage;
        }
    }
}
