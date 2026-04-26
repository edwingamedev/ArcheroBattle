using UnityEngine;

namespace EdwinGameDev.Movement
{
    public interface IMoveable
    {
        void Setup(float movementSpeed);
        void SetDirection(Vector3 direction);
        void Stop();
    }
}