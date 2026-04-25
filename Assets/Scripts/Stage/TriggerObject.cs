using System;
using EdwinGameDev.Target;
using UnityEngine;

namespace EdwinGameDev.Stage
{
    public class TriggerObject : MonoBehaviour
    {
        public event Action OnTrigger;

        public void Enable()
        {
            gameObject.SetActive(true);
        }
        
        public void Disable()
        {
            gameObject.SetActive(false);
        }
        
        private void OnTriggerEnter(Collider other)
        {
            if (!other.TryGetComponent(out ITarget target))
            {
                return;
            }

            if (!target.IsPlayer)
            {
                return;
            }

            OnTrigger?.Invoke();
        }
    }
}