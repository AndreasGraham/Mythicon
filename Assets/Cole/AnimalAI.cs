using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AnimalAI : MonoBehaviour
{
    public float WanderRadius;
    public float WanderTimer;

    public Transform Target;
    private NavMeshAgent Agent;
    private float Timer;
    public float EvadeDist;

	// Use this for initialization
	void Start ()
    {
        Agent = GetComponent<NavMeshAgent>();
        Vector3 newPos = RandomNavMesh(transform.position, WanderRadius, -1);
        //Agent.SetDestination(newPos);
        Agent.destination = newPos;
        Timer = 0;
    }
	
	// Update is called once per frame
	void Update ()
    {
        //Timer = WanderTimer;
        Timer += Time.deltaTime;
        float dist = Vector3.Distance(Target.position, transform.position);
        if (dist < EvadeDist)
        {
            Agent.speed = 20;
            Vector3 Away = (transform.position + Target.position);
            Agent.destination = Away;
        }
       
        else if (Timer >= WanderTimer)
        {
            Agent.speed = 10;
            Vector3 newPos = RandomNavMesh(transform.position, WanderRadius, -1);
            Debug.Log(newPos);
            //Agent.SetDestination(newPos);
            Agent.destination = newPos;
            Timer = 0;

        }

    }

    public Vector3 RandomNavMesh(Vector3 origin, float dist, int layermask)
    {

        Vector3 randDirection = Random.insideUnitSphere * dist;
        
        randDirection += origin;
        randDirection.y = transform.position.y;
        NavMeshHit navHit;

        NavMesh.SamplePosition(randDirection, out navHit, dist, layermask);

        return navHit.position;

        
    }
    
}
