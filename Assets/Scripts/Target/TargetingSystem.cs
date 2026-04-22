using UnityEngine;

namespace EdwinGameDev.Target
{
    public class TargetingSystem
    {
        private readonly ITarget _owner;
        
        public TargetingSystem(ITarget owner)
        {
            _owner = owner;
        }

        public ITarget GetClosest(Vector3 origin, float maxDistance)
        {
            ITarget closest = null;
            float minDist = float.MaxValue;

            foreach (ITarget target in TargetProvider.GetTargets())
            {
                if (!target.IsAlive || target.IsPlayer == _owner.IsPlayer)
                {
                    continue;
                }

                float dist = Vector3.SqrMagnitude(
                    target.Transform.position - origin
                );

                if (!(dist < minDist) || !(dist <= maxDistance * maxDistance))
                {
                    continue;
                }

                minDist = dist;
                closest = target;
            }

            return closest;
        }
    }
}