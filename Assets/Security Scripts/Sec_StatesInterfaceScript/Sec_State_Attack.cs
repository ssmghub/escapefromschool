using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Sec_State_Attack : Sec_IState
{
    public Sec_State_Attack(SecurityController owner) 
    { 
        this.owner = owner; 
    }

    SecurityController owner;
    NavMeshAgent agent;

    public void Enter()
    {
        // Debug.Log("entering attack state");
        agent = owner.GetComponent<NavMeshAgent>();

        if (owner.seenTarget)
        {
            agent.destination = owner.lastSeenPosition;
            agent.isStopped = false;
        }
    }
    public void Execute()
    {
        // Debug.Log("updating attack state");

        agent.destination = owner.lastSeenPosition;
        agent.isStopped = false;

        if (!agent.pathPending && agent.remainingDistance < 3.0f)
        {
            agent.isStopped = true;
        }

        // fire on the player
        owner.fire();

        if (owner.seenTarget != true)
        {
            // Debug.Log("lost sight");
            // Security Don't Search Player --> only protect exits
            owner.sec_StateMachine.ChangeState(new Sec_State_Patrol(owner));
        }
    }

    public void Exit()
    {
        // Debug.Log("exiting attack state");
        agent.isStopped = true;
    }
}