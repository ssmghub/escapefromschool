using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Sec_State_Search : Sec_IState
{
    public Sec_State_Search(SecurityController owner) 
    { 
        this.owner = owner; 
    }

    SecurityController owner;
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
        if (!agent.pathPending && agent.remainingDistance < 3.0f)
        {
            agent.isStopped = true;
        }

        if(Time.time > t + 5)
        // if(Time.time > t + 10)
        {
            owner.sec_StateMachine.ChangeState(new Sec_State_Patrol(owner));
        }
        
        if (owner.seenTarget == true)
        {
            // Debug.Log("gained sight");
            owner.sec_StateMachine.ChangeState(new Sec_State_Attack(owner));
        }

    }

    public void Exit()
    {
        // Debug.Log("exiting searching state");
        agent.isStopped = true;
    }
}