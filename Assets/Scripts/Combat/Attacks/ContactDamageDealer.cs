using System.Collections.Generic;
using EdwinGameDev.Target;
using UnityEngine;

namespace EdwinGameDev.Combat.Attacks
{
    public class ContactDamageDealer : MonoBehaviour
    {
        [SerializeField] private int damage = 5;
        [SerializeField] private float cooldown = 0.5f;

        private readonly Dictionary<ITarget, float> _nextHitTime = new();

        private ITarget _owner;

        private void Awake()
        {
            _owner = GetComponent<ITarget>();

            if (_owner == null)
            {
                Debug.LogError("ContactDamageDealer requires an ITarget on the same GameObject.");
            }
        }
        
        private void OnTriggerStay(Collider other)
        {
            if (_owner == null)
            {
                Debug.LogError("ContactDamageDealer requires an ITarget on the same GameObject.");
                return;
            }
            
            if (!other.TryGetComponent(out ITarget target))
            {
                return;
            }

            if (target == _owner)
            {
                return;
            }

            if (target.IsPlayer == _owner.IsPlayer)
            {
                return;
            }

            AddTarget(target);
        }

        private void AddTarget(ITarget target)
        {
            float now = Time.time;

            if (_nextHitTime.TryGetValue(target, out float nextTime))
            {
                if (now < nextTime)
                    return;
            }

            target.TakeDamage(damage);
            _nextHitTime[target] = now + cooldown;
        }

        private void OnTriggerExit(Collider other)
        {
            if (!other.TryGetComponent(out TargetAdapter target))
            {
                return;
            }

            _nextHitTime.Remove(target);
        }
    }
}
