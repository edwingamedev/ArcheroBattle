using EdwinGameDev.Animation;
using EdwinGameDev.Movement;
using UnityEngine;

namespace EdwinGameDev.Character
{
    public class MovementModule
    {
        private readonly IMoveable _moveable;
        private readonly IMovementAnimation _animation;

        public MovementModule(IMoveable moveable, IMovementAnimation animation, float movementSpeed)
        {
            _moveable = moveable;
            _animation = animation;
            _animation.SetMoveSpeed(movementSpeed);
        }

        public void Move(Vector3 direction)
        {
            if (direction.magnitude > 0)
            {
                _moveable.SetDirection(direction);
                _animation.SetMoving(true);
                return;
            }

            Stop();
        }

        public void Stop()
        {
            _animation.SetMoving(false);
            _moveable.Stop();
        }
    }
}