using System;
using UnityEngine;

namespace EdwinGameDev.Animation
{
    public class CharacterAnimatorAdapter : MonoBehaviour, IMovementAnimation, IAttackAnimation, IHealthAnimation
    {
        [SerializeField] private Animator animator;
        private Action _onAttackHit;

        private static readonly int Run = Animator.StringToHash("Run");
        private static readonly int Idle = Animator.StringToHash("Idle");
        private static readonly int Attack = Animator.StringToHash("Attack");
        private static readonly int Die = Animator.StringToHash("Die");
        private static readonly int TakeDamage = Animator.StringToHash("TakeDamage");

        public void PlayAttack()
        {
            animator.SetTrigger(Attack);
        }

        public void SetOnAttackHit(Action callback)
        {
            _onAttackHit = callback;
        }

        public void OnAttackHit()
        {
            _onAttackHit?.Invoke();
        }

        public void PlayDeath()
        {
            animator.SetTrigger(Die);
        }

        public void PlayHit()
        {
            animator.SetTrigger(TakeDamage);
        }

        public void SetMoving(bool isMoving)
        {
            if (isMoving)
            {
                PlayMove();
                return;
            }
            
            PlayIdle();
        }
        
        private void PlayIdle()
        {
            animator.Play(Idle);
        }

        private void PlayMove()
        {
            animator.Play(Run);
        }
    }
}