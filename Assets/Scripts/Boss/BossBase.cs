using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ebac.StateMachine;
using DG.Tweening;


namespace Boss
{
    public enum BossAction
    {
        INIT,
        IDLE,
        WALK,
        ATTACK
    }
    public class BossBase : MonoBehaviour
    {
        [Header("Animation")]
        public float startAnimationDuration = .5f;
        public Ease startAnimationEase = Ease.OutBack;

        public float speed = 5f;
        public List<Transform> wayPoints;

        private StateMachine<BossAction> stateMachine;

        private void Awake()
        {
            Init();
        }   

        private void Init()
        {
            stateMachine = new StateMachine<BossAction>();
            stateMachine.Init();

            stateMachine.RegisterStates(BossAction.INIT, new BossStateInit());
            stateMachine.RegisterStates(BossAction.WALK, new BossStateWalk());

        }

        

        #region
        public void GoToRandomPoint()
        {
            StartCoroutine(GoToPointCoroutine(wayPoints[Random.Range(0, wayPoints.Count)]));
        }

        IEnumerator GoToPointCoroutine(Transform t)
        {
            while (Vector3.Distance(transform.position, t.position) > 1f)
            { 
            transform.position = Vector3.MoveTowards(transform.position, t.position,Time.deltaTime * speed);
            yield return new WaitForEndOfFrame();
            }
        }
        #endregion
        #region Animation
        public void StartInitAnimation()
        {
            transform.DOScale(0, startAnimationDuration). SetEase(startAnimationEase).From();
        }
        #endregion

        #region Debug
        [NaughtyAttributes.Button]
        private void SwitchInit()
        {
            stateMachine.SwitchState(BossAction.INIT);
        }
        [NaughtyAttributes.Button]
        private void SwitchWalk()
        {
            stateMachine.SwitchState(BossAction.WALK);
        }
        #endregion

        #region State Machine
        public void SwitchState(BossAction state)
        {
            stateMachine.SwitchState(state, this);
        }
        #endregion
    }
}

