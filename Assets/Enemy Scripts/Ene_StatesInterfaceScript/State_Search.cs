using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class State_Search : IState
{
    public State_Search(EnemyController owner) 
    { 
        this.owner = owner; 
    }

    EnemyController owner;
    NavMeshAgent agent;

    float t;

    public void Enter()
    {
        // Debug.Log("entering search state");
        agent = owner.GetComponent<NavMeshAgent>();
        
        agent.destination = owner.lastSeenPosition;
        agent.isStopped = false;

        t = Time.time;
    }
    public void Execute()
    {
        // Debug.Log("updating searching state");
        if (!agent.pathPending && agent.remainingDistance < 0.5f)
        {
            agent.isStopped = true;
        }

        if(Time.time > t + 5)
        // if(Time.time > t + 10)
        {
            owner.stateMachine.ChangeState(new State_Patrol(owner));
        }
        
        if (owner.seenTarget == true)
        {
            // Debug.Log("gained sight");
            owner.stateMachine.ChangeState(new State_Attack(owner));
        }

    }

    public void Exit()
    {
        // Debug.Log("exiting searching state");
        agent.isStopped = true;
    }
}