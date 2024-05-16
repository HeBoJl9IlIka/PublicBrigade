using Nevalyashka.Brigade.Model;

namespace Nevalyashka.Brigade.Factory
{
    public class LiftableModelFactory : ModelFactory<Liftable>
    {
        public LiftableModelFactory()
        {
            IModelTemplate<Liftable>[] templates =
            {
                new LiftableTemplate(),
                new ConstructionMaterialPackageLiftableTemplate(),
                new WateringCanLiftableTemplate(),
                new HammerLiftableTemplate(),
                new RepairDrawingLiftableTemplate()
            };

            Templates = templates;
        }
    }

    public class LiftableTemplate : IModelTemplate<Liftable>
    {
        public Liftable GetModel<T2, T3, T4, T5>(T2 model, T3 isEasy, T4 obj2 = default, T5 obj3 = default)
        {
            if (model != null)
                return null;

            bool temporary;

            if (typeof(T3) == typeof(bool))
                temporary = (bool)(object)isEasy;
            else
                return null;

            return new Liftable(temporary);
        }
    }

    public class ConstructionMaterialPackageLiftableTemplate : IModelTemplate<Liftable>
    {

        public Liftable GetModel<T2, T3, T4, T5>(T2 model, T3 isEasy, T4 obj2 = default, T5 obj3 = default)
        {
            if (model is ConstructionMaterialPackage == false)
                return null;

            bool temporary;

            if (typeof(T3) == typeof(bool))
                temporary = (bool)(object)isEasy;
            else
                return null;

            return new ConstructionMaterialPackageLiftable(temporary, model as ConstructionMaterialPackage);
        }
    }

    public class WateringCanLiftableTemplate : IModelTemplate<Liftable>
    {
        public Liftable GetModel<T2, T3, T4, T5>(T2 model, T3 isEasy, T4 obj2 = default, T5 obj3 = default)
        {
            if (model is WateringCan == false)
                return null;

            bool temporary;

            if (typeof(T3) == typeof(bool))
                temporary = (bool)(object)isEasy;
            else
                return null;

            return new WateringCanLiftable(temporary, model as WateringCan);
        }
    }

    public class HammerLiftableTemplate : IModelTemplate<Liftable>
    {
        public Liftable GetModel<T2, T3, T4, T5>(T2 model, T3 isEasy, T4 obj2 = default, T5 obj3 = default)
        {
            if (model is Hammer == false)
                return null;

            bool temporary;

            if (typeof(T3) == typeof(bool))
                temporary = (bool)(object)isEasy;
            else
                return null;

            return new HammerLiftable(temporary, model as Hammer);
        }
    }

    public class RepairDrawingLiftableTemplate : IModelTemplate<Liftable>
    {
        public Liftable GetModel<T2, T3, T4, T5>(T2 model, T3 isEasy, T4 obj2 = default, T5 obj3 = default)
        {
            if (model is RepairDrawing == false)
                return null;

            bool temporary;

            if (typeof(T3) == typeof(bool))
                temporary = (bool)(object)isEasy;
            else
                return null;

            return new RepairDrawingLiftable(temporary, model as RepairDrawing);
        }
    }
}
