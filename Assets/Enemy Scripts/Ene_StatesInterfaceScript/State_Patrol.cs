using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class State_Patrol: IState
{
    EnemyController owner;
    NavMeshAgent agent;
    Waypoint waypoint;

    public State_Patrol(EnemyController owner) // constructor
    { 
        this.owner = owner; 
    }
    
    public void Enter()
    {
        // Debug.Log("entering patrol state");
        waypoint = owner.waypoint;
        agent = owner.GetComponent<NavMeshAgent>();
        
        agent.destination = waypoint.transform.position;
        // start moving, in case we were previously stopped
        agent.isStopped = false;
    }

    public void Execute()
    {
        // Debug.Log("updating patrol state");
        
        // same as before
        // 脚本使用remainingDistance属性检查代理与目的地的距离。当此距离非常小时，将调用GotoNextPoint以开始下一段巡逻。
        if (!agent.pathPending && agent.remainingDistance < 0.5f)
        {
            Waypoint nextWaypoint = waypoint.nextWaypoint;
            waypoint = nextWaypoint;
            agent.destination = waypoint.transform.position;
        }
        if(owner.seenTarget)
        {
            // Debug.Log("entering attack state");
            owner.stateMachine.ChangeState(new State_Attack(owner));
        }
    }

    public void Exit()
    {
        // Debug.Log("exiting patrol state");
        // stop moving
        agent.isStopped = true;
    }

}