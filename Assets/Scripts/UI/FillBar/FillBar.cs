using UnityEngine;
using UnityEngine.UI;

namespace EdwinGameDev.UI.FillBar
{
    public class FillBar : MonoBehaviour
    {
        [SerializeField] protected Image fillBar;
        protected float Percent;

        public virtual void UpdateUIEventHandler(int currentAmount, int maxAmount, int valueChanged)
        {
            Percent = currentAmount / (float)maxAmount;
            Percent = Mathf.Clamp01(Percent);
            fillBar.fillAmount = Percent;
        }
    }
}