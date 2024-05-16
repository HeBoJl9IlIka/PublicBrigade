using System;
using UnityEngine;

namespace Nevalyashka.Brigade.Model
{
    public class JoystickModel
    {
        public event Action<Vector2> Dragging;

        public void SetDirection(Vector2 direction)
        {
            float axisX = Mathf.Clamp(direction.x, -1, 1);
            float axisY = Mathf.Clamp(direction.y, -1, 1);
            direction = new Vector2(axisX, axisY);

            Dragging?.Invoke(direction);
        }
    }
}
