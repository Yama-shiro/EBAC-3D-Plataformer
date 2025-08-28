using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSMExample : MonoBehaviour
{
        public enum ExampleEnum
        {
            State_One,
            State_Two,
            State_Three
        }

    public StateMachine<ExampleEnum> stateMachine;

    private void Start()
    {
        stateMachine = new StateMachine<ExampleEnum>();
        stateMachine.Init();
        stateMachine.RegisterStates(ExampleEnum.State_One, new StateBase());
        stateMachine.RegisterStates(ExampleEnum.State_Two, new StateBase());
    }

}
