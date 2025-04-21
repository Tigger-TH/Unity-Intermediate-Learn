using UnityEngine;
using UnityEngine.AI;

public class Roaming : State
{
    public Roaming(Enemy enemy, NavMeshAgent agent) : base(enemy, agent)
    {
        Name = STATE.ROAMING;
    }

    public override void Enter()
    {
        // How many location in patrol
        int LocationQuantity = EnemyClass.ObserveLocation.Length;

        Agent.SetDestination(SearchWayPoint(LocationQuantity));

        base.Enter();
    }

    public override void Update()
    {
        if(Agent.remainingDistance <.5f)
        {
            //If remain distance is less than 0.5m
            //Set NextState to idle
            //And change Stage to Exit
            //NextState = new Idle(EnemyClass, Agent);
            //Stage = EVENT.EXIT;
            int LocationQuantity = EnemyClass.ObserveLocation.Length;

            Agent.SetDestination(SearchWayPoint(LocationQuantity));

            Stage = EVENT.ENTER;
        }
        base.Update();
    }
    public override void Exit()
    {
        base.Exit();
    }
    private Vector3 SearchWayPoint(int locationQuantity)
    {
        int index = Random.Range(0,locationQuantity);

        Vector3 destination = EnemyClass.ObserveLocation[index].position;
        /*
        Find if NavMesh exit on that position or not
        If not find the closest one,
        if there's no closest random another point
        */
        NavMeshHit hit;
        if(NavMesh.SamplePosition(destination, out hit, 1.0f, NavMesh.AllAreas))
        {
            destination = hit.position;
        }
        else
        {
            destination = SearchWayPoint(locationQuantity);
        }
        return destination;
    }


}
