using UnityEngine;

namespace EdwinGameDev.Stage
{
    [CreateAssetMenu(fileName = "Stage Container", menuName = "Stage Container")]
    public class StageContainer : ScriptableObject
    {
        public Stage[] stages;
    }
}