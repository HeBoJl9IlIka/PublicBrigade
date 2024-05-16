using System;
using UnityEngine;

namespace Nevalyashka.Brigade.Factory
{
    public abstract class PresenterFactory<T, Y, U, I> : MonoBehaviour where T : MonoBehaviour
    {
        [SerializeField] protected T[] Templates;

        public abstract T GetTemplate(Y obj = default, U obj1 = default, I obj2 = default);

        public T Create(Transform parent, Y obj = default, U obj1 = default, I obj2 = default)
        {
            T template = GetTemplate(obj, obj1, obj2);

            if (template == null)
                throw new ArgumentNullException(nameof(template));

            T newObj = Instantiate(template, parent);

            return newObj;
        }
    }
}
