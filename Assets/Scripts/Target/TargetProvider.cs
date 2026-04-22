using System.Collections.Generic;
using UnityEngine;

namespace EdwinGameDev.Target
{
    public static class TargetProvider
    {
        private static readonly List<ITarget> Targets = new();

        public static void AddTarget(ITarget target)
        {
            Targets.Add(target);
            Debug.Log($"Add target{target}");
        }

        public static void RemoveTarget(ITarget target)
        {
            Targets.Remove(target);
            Debug.Log($"Remove target{target}");
        }

        public static List<ITarget> GetTargets()
        {
            return Targets;
        }
    }
}