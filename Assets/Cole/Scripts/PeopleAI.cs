using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PeopleAI : MonoBehaviour
{
    public float WanderRadius;
    public float WanderTimer;

    private Transform Target;
    private NavMeshAgent Agent;
    private float Timer;
    private Transform Villager = null;

    // Use this for initialization
    void Start()
    {
        Agent = GetComponent<NavMeshAgent>();
        Timer = WanderTimer;
    }

    // Update is called once per frame
    void Update()
    {
        Timer += Time.deltaTime;

        if (Timer >= WanderTimer)
        {
            Vector3 newPos = RandomNavMesh(transform.position, WanderRadius, -1);
            Agent.SetDestination(newPos);
            Timer = 0;
        }

        if (Villager == null)
        {
            Villager = GameObject.FindGameObjectWithTag("Villager").transform;
            Vector3 relativePos = Villager.position - transform.position;
            Quaternion rotation = Quaternion.LookRotation(relativePos);
            transform.rotation = rotation;
            Villager.position - transform.position;
        }

    }

    public static Vector3 RandomNavMesh(Vector3 origin, float dist, int layermask)
    {

        Vector3 randDirection = Random.insideUnitSphere * dist;

        randDirection += origin;

        NavMeshHit navHit;

        NavMesh.SamplePosition(randDirection, out navHit, dist, layermask);

        return navHit.position;


    }

}
