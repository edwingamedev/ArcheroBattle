using System;
using UnityEngine;

namespace EdwinGameDev.Animation
{
    public class CharacterAnimatorAdapter : MonoBehaviour, IMovementAnimation, IAttackAnimation, IHealthAnimation
    {
        [SerializeField] private Animator animator;
        private Action _onAttackHit;
        
        private static readonly int IsDead = Animator.StringToHash("IsDead");
        private static readonly int IsAttacking = Animator.StringToHash("IsAttacking");
        private static readonly int IsMoving = Animator.StringToHash("IsMoving");
        private static readonly int Hit = Animator.StringToHash("Hit");

        public void SetMoving(bool isMoving)
        {
            if (isMoving)
            {
                SetAttacking(false);
            }
            
            animator.SetBool(IsMoving, isMoving);
        }
        
        public void SetAttacking(bool isAttacking)
        {
            animator.SetBool(IsAttacking, isAttacking);
        }

        public void TakeDamage()
        {
            Debug.Log("TakeDamage animation");
            animator.SetTrigger(Hit);
        }
        
        public void SetDeath(bool isDead)
        {
            animator.SetBool(IsDead, isDead);
        }
        
        public void SetOnAttackHit(Action callback)
        {
            _onAttackHit = callback;
        }

        public void OnAttackHit()
        {
            _onAttackHit?.Invoke();
        }
    }
}