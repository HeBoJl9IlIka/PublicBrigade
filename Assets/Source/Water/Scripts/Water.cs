using System;
using UnityEngine;

namespace Nevalyashka.Brigade.Model
{
    public class Water
    {
        public event Action Selected;
        public event Action Canceled;

        public void Select()
        {
            Selected?.Invoke();
        }

        public void Cancel()
        {
            Canceled?.Invoke();
        }
    }
}
