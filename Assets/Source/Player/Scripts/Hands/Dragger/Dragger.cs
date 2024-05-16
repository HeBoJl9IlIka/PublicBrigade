using System;
using UnityEngine;

namespace Nevalyashka.Brigade.Model
{
    public class Dragger : Hands<Liftable>
    {
        private Transform _point;

        public event Action<bool> Dragging;
        public event Action<bool> Dropping;

        public Dragger(PlayerRouter playerRouter, Transform point) : base(playerRouter)
        {
            _point = point;
        }

        public override void SetObject(Liftable targetObject)
        {
            if (CurrentObject != null)
                return;

            if (TargetObject == targetObject)
                return;

            if (targetObject.IsBusy)
                return;

            Cancel();
            TargetObject = targetObject;
            TargetObject.Select();
        }

        public override void Cancel()
        {
            if (CurrentObject != null)
                return;

            if (TargetObject == null)
                return;

            if (TargetObject.IsBusy)
                return;

            TargetObject.Cancel();
            TargetObject = null;
        }

        protected override void OnDraggingDropping()
        {
            Drop();
            Drag();
        }

        protected override void OnThrowing()
        {
            if (CurrentObject == null)
                return;

            if (CurrentObject.IsEasy == false)
                return;

            Dropping?.Invoke(CurrentObject.IsEasy);
            CurrentObject.Throw(_point);
            CurrentObject = null;
        }

        private void Drag()
        {
            if (TargetObject == null)
                return;

            if (TargetObject.IsBusy)
                return;

            CurrentObject = TargetObject;
            CurrentObject.Drag(_point);
            TargetObject.Cancel();
            TargetObject = null;
            Dragging?.Invoke(CurrentObject.IsEasy);
        }

        private void Drop()
        {
            if (CurrentObject == null)
                return;

            CurrentObject.Drop(_point);
            Dropping?.Invoke(CurrentObject.IsEasy);
            CurrentObject = null;
            return;
        }
    }
}
