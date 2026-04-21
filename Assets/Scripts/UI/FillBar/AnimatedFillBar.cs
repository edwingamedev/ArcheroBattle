using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace EdwinGameDev.UI.FillBar
{
    public class AnimatedFillBar : FillBar
    {
        [SerializeField] private Image damageBar;

        public float delayBeforeDamageBar = 0.2f;
        public float damageBarSpeed = 1.5f;

        private Coroutine _damageRoutine;

        public override void UpdateUIEventHandler(int currentAmount, int maxAmount, int valueChanged)
        {
            float previousPercent = fillBar.fillAmount;

            base.UpdateUIEventHandler(currentAmount, maxAmount, valueChanged);

            // If healing, both bars should usually jump up immediately
            if (Percent >= previousPercent)
            {
                damageBar.fillAmount = Percent;
                if (_damageRoutine == null)
                {
                    return;
                }

                StopCoroutine(_damageRoutine);
                _damageRoutine = null;
                return;
            }

            // If taking damage, white bar animates down from old value
            if (_damageRoutine != null)
            {
                StopCoroutine(_damageRoutine);
            }

            damageBar.fillAmount = previousPercent;
            _damageRoutine = StartCoroutine(AnimateDamageBar(Percent));
        }

        private IEnumerator AnimateDamageBar(float targetPercent)
        {
            yield return new WaitForSeconds(delayBeforeDamageBar);
            while (damageBar.fillAmount > targetPercent)
            {
                damageBar.fillAmount = Mathf.MoveTowards(
                    damageBar.fillAmount,
                    targetPercent,
                    damageBarSpeed * Time.deltaTime
                );
                yield return null;
            }

            damageBar.fillAmount = targetPercent;
            _damageRoutine = null;
        }
    }
}