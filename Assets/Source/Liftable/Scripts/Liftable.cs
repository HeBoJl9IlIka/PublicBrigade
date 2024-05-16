using System;
using UnityEngine;

namespace Nevalyashka.Brigade.Model
{
    public class Liftable
    {
        public event Action Selected;
        public event Action Canceled;
        public event Action<Transform> Dragging;
        public event Action<Transform> Dropped;
        public event Action<Transform> Throwed;

        public bool IsBusy { get; private set; }
        public bool IsDragged { get; private set; }
        public bool IsEasy { get; private set; }

        public Liftable(bool isEasy)
        {
            IsEasy = isEasy;
        }

        public void Select()
        {
            Selected?.Invoke();
        }

        public void Cancel()
        {
            Canceled?.Invoke();
        }

        public void Drag(Transform point)
        {
            IsDragged = true;
            IsBusy = IsEasy ? true : false;
            Dragging?.Invoke(point);
        }

        public void Drop(Transform point)
        {
            IsDragged = false;
            IsBusy = false;
            Dropped?.Invoke(point);
        }

        public void Throw(Transform point)
        {
            IsDragged = false;
            IsBusy = false;
            Throwed?.Invoke(point);
        }
    }
}
