namespace Nevalyashka.Brigade.Factory
{
    public abstract class ModelFactory<T1>
    {
        protected IModelTemplate<T1>[] Templates;

        public T1 Create<T2, T3, T4, T5>(T2 obj, T3 obj1, T4 obj2, T5 obj3)
        {
            foreach (var template in Templates)
            {
                T1 temporary = template.GetModel(obj, obj1, obj2, obj3);

                if (temporary != null)
                    return temporary;
            }

            return default;
        }
    }

    public interface IModelTemplate<T1>
    {
        T1 GetModel<T2, T3, T4, T5>(T2 obj = default, T3 obj1 = default, T4 obj2 = default, T5 obj3 = default);
    }
}
