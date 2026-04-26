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
        private static readonly int AttackSpeed = Animator.StringToHash("AttackSpeed");
        private static readonly int MovementSpeed = Animator.StringToHash("MovementSpeed");
        
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

        public void SetAttackSpeed(float speed)
        {
            animator.SetFloat(AttackSpeed, speed);
        }
        
        public void SetMoveSpeed(float speed)
        {
            animator.SetFloat(MovementSpeed, speed);
        }
    }
}