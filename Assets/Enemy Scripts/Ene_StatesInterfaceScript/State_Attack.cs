using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class State_Attack : IState
{
    public State_Attack(EnemyController owner) 
    { 
        this.owner = owner; 
    }

    EnemyController owner;
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

        if (!agent.pathPending && agent.remainingDistance < 5.0f)
        {
            agent.isStopped = true;
        }

        // fire on the player
        owner.fire();

        if (owner.seenTarget != true)
        {
            Debug.Log("lost sight");
            // search for the player
            owner.stateMachine.ChangeState(new State_Search(owner));
        }
    }

    public void Exit()
    {
        // Debug.Log("exiting attack state");
        agent.isStopped = true;
    }
}