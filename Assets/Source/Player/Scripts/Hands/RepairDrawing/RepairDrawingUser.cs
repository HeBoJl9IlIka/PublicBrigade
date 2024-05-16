using Unity.VisualScripting;

namespace Nevalyashka.Brigade.Model
{
    public class RepairDrawingUser : Hands<Null>
    {
        private Dragger _dragger;
        private CameraRotator _cameraRotator;
        private TaskGoalIndicator _taskGoalIndicator;
        private bool _isShowed;

        private RepairDrawingLiftable Liftable => _dragger.CurrentObject as RepairDrawingLiftable;
        private RepairDrawing Model => Liftable != null ? Liftable.Model : null;

        public RepairDrawingUser(PlayerRouter playerRouter, Dragger dragger, CameraRotator cameraRotator, TaskGoalIndicator taskGoalIndicator)
            : base(playerRouter)
        {
            _dragger = dragger;
            _cameraRotator = cameraRotator;
            _taskGoalIndicator = taskGoalIndicator;
        }

        public override void Cancel()
        {
            
        }

        public override void SetObject(Null @null)
        {
            
        }

        protected override void OnDraggingDropping()
        {
            if (Model != null)
                return;

            if (_isShowed)
            {
                _taskGoalIndicator.HideTaskTarget();
                _isShowed = false;
            }
        }

        protected override void OnUsing()
        {
            if (Model == null)
                return;

            if (_isShowed)
            {
                _taskGoalIndicator.HideTaskTarget();
                _isShowed = false;
            }
            else
            {
                _taskGoalIndicator.ShowTaskTarget();
                _isShowed = true;
            }
        }

        protected override void OnRotating(float value)
        {
            if (Model == null)
                return;

            _cameraRotator.Rotate(value);
        }

        protected override void OnThrowing()
        {
            if (Model != null)
                return;

            if (_isShowed)
            {
                _taskGoalIndicator.HideTaskTarget();
                _isShowed = false;
            }
        }
    }
}
