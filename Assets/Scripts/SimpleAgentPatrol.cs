using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(ObstacleAgent))]
public class SimpleAgentPatrol : MonoBehaviour
{
    [SerializeField]
    private Transform[] Waypoints;

    private ObstacleAgent Agent;
    private NavMeshAgent NavMeshAgent;
    [SerializeField]
    private int Index = 0;
    private float StoppingDistance = 0.05f;

    private float UpdateDelay = 0.1f;
    private float LastUpdate;

    private void Awake()
    {
        Agent = GetComponent<ObstacleAgent>();
        NavMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void Start()
    {
        Agent.SetDestination(Waypoints[0].position);
    }

    private void Update()
    {
        if (LastUpdate + UpdateDelay < Time.time)
        {
            LastUpdate = Time.time;
            if (NavMeshAgent.enabled && NavMeshAgent.remainingDistance < StoppingDistance)
            {
                Index++;
                if (Index >= Waypoints.Length)
                {
                    Index = 0;
                }

                Agent.SetDestination(Waypoints[Index].position);
            }
        }
    }
}