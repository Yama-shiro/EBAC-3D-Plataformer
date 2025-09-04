using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Animation;

namespace Enemy
{

    public class EnemyBase : MonoBehaviour
    {
        
        public float startLife = 10f;

        [SerializeField] private float _currentLife;

        [Header("Animation")]
        public AnimationBase animationBase;

        [Header("Start Animation")]
        public float startAnimDuration = 0.2f;
        public Ease startAnimationEase = Ease.OutBack;
        public bool startWithBornAnimation = true;

        private void Awake()
        {
            Init();
        }

        protected void ResetLife()
        {
            _currentLife = startLife;
        }

        protected virtual void Init()
        {
            ResetLife();
            if(startWithBornAnimation)
                BornAnimation();
        }

        protected virtual void Kill()
        {
            OnKill();
        }

        protected virtual void OnKill()
        {
            Destroy(gameObject, 3f);
            PlayAnimayionByTrigger(AnimationType.DEATH);
        }

        public void OnDamage(float f)
        {
            _currentLife -= f;
            if (_currentLife <= 0)
            {
                Kill();
            }
        }

        #region ANIMATION
        private void BornAnimation()
        {
            transform.DOScale(0, startAnimDuration).SetEase(startAnimationEase).From();
        }

        public void PlayAnimayionByTrigger(AnimationType animationType)
        {
            animationBase.PlayAnimayionByTrigger(animationType);
        }
        #endregion


        //Debug
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.T))
            {
                OnDamage(5f);
            }
        }
    }
    
}