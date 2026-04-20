using UnityEngine;

namespace EdwinGameDev.MovementSystem
{
    public interface IMoveable
    {
        void SetDirection(Vector3 direction);
        void Stop();
    }
}