using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PeopleAI : MonoBehaviour
{
    public float WanderRadius;
    public float timeToWander;
    public float timeToTalk;

    private Transform Target;
    private NavMeshAgent Agent;
    private float wanderTimer;
    private float talkTimer;
    private Transform Villager = null;

    // Use this for initialization
    void Start()
    {
        Agent = GetComponent<NavMeshAgent>();
        wanderTimer = timeToWander;
    }

    // Update is called once per frame
    void Update()
    {
        wanderTimer += Time.deltaTime;
        talkTimer += Time.deltaTime;

        if (wanderTimer >= timeToWander && Villager == null)
        {
            Vector3 newPos = RandomNavMesh(transform.position, WanderRadius, -1);
            Agent.SetDestination(newPos);
            wanderTimer = 0;
        }

        if (Villager == null && talkTimer >= timeToTalk)
        {
            Villager = GameObject.FindGameObjectWithTag("Villager").transform;
            talkTimer = 0;
           
        }
        if(Villager != null && talkTimer >= 5)
        {
            Villager = null;
            Debug.Log("Fuck");
        }

        if(Villager != null)
        {
            Agent.destination = Villager.position;
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
