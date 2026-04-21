using UnityEngine;

namespace EdwinGameDev.Movement
{
    public interface IMoveable
    {
        void SetDirection(Vector3 direction);
        void Stop();
    }
}