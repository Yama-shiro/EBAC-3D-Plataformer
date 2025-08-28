using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ebac.StateMachine
{
    public class StateBase 
{
    public virtual void OnStateEnter()
    {
        Debug.Log("onStateEnter");
    }

    public virtual void OnStateStay()
    {
        Debug.Log("onStateStay");
    }

    public virtual void OnStateExit()
    {
        Debug.Log("onStateExit");
    }
}
}

