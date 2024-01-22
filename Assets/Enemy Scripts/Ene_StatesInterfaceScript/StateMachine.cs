using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IState
{
    void Enter();
    void Execute();
    void Exit();
}

public class StateMachine // : MonoBehaviour
{
    IState currentState;

    public void ChangeState(IState newState)
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
