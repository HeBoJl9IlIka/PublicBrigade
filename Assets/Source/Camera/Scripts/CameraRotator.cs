using System;

namespace Nevalyashka.Brigade.Model
{
    public class CameraRotator
    {
        public float CurrentAngle { get; private set; }

        public event Action<float> Rotated;

        public void Rotate(float value)
        {
            float angle = 90 * value;
            CurrentAngle += angle;

            if (CurrentAngle < -180)
                CurrentAngle = 90;

            if (CurrentAngle == 180)
                CurrentAngle = -180;

            Rotated?.Invoke(CurrentAngle);
        }
    }
}
