using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Sec_IState
{
    void Enter();
    void Execute();
    void Exit();
}

public class Sec_StateMachine // : MonoBehaviour
{
    Sec_IState currentState;

    public void ChangeState(Sec_IState newState)
    {
        if (currentState != null) // 若有上一个state --> currentState不为空
            currentState.Exit(); // stop doing current state
        
        // new state
        currentState = newState;
        currentState.Enter();
    }

    // Update is called once per frame
    public void Update()
    {
        if (currentState != null) 
        currentState.Execute();
    }
}
