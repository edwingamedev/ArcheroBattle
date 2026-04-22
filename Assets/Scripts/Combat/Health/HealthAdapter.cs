using UnityEngine;

namespace EdwinGameDev.Combat.Health
{
    public class HealthAdapter : MonoBehaviour
    {
        public IHealth Health { get; private set; }

        public void Initialize(IHealth health)
        {
            Health = health;
        }
    }
}