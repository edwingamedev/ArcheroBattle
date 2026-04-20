using UnityEngine;

namespace EdwinGameDev.AnimationSystem
{
    public class HeroAnimatorAdapter : MonoBehaviour, IUnitAnimator
    {
        [SerializeField] private Animator animator;

        public void PlayIdle()
        {
            animator.Play("Idle");
        }

        public void PlayMove()
        {
            animator.Play("Run");
        }

        public void PlayAttack()
        {
            animator.Play("Attack");
        }

        public void PlayDeath()
        {
            animator.Play("Die");
        }

        public void PlayTakeDamage()
        {
            animator.Play("TakeDamage");
        }
    }
}