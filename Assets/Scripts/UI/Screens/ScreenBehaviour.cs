using UnityEngine;

namespace EdwinGameDev.UI.Screens
{
    [System.Serializable]
    public abstract class ScreenBehaviour : MonoBehaviour
    {
        public abstract void OnActivate();
        public abstract void OnDeactivate();
    }
}