using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

enum AIStates
{
    TALK, WALK
};


public class AIExample : MonoBehaviour
{
    private NavMeshAgent agent;
    private Animator anim;
    private Transform villager = null;
    private AIStates states;
    private float delay;
    [SerializeField] private float wanderRadius;

	// Use this for initialization
	void Start ()
    {
        agent = GetComponent<NavMeshAgent>();
        //anim = GetComponent<Animator>();
        states = AIStates.WALK;
	}
	
	// Update is called once per frame
	void Update ()
    {
        Ray ray = new Ray(transform.position, transform.right);
        RaycastHit hit;
        if (Physics.SphereCast(ray, 360f, out hit))
        {
            if (hit.collider.tag == "Villager")
            {
                villager = hit.transform;
                states = AIStates.TALK;
            }
            else
            {
                villager = null;
                states = AIStates.WALK;
            }            
        }
        if (delay <= 0f)
        {
            switch (states)
            {
                case AIStates.WALK:
                    Vector3 newPos = RandomNavMesh(transform.position, wanderRadius, -1);
                    agent.SetDestination(newPos);
                    //anim.SetFloat("Speed", 1f);
                    break;
                case AIStates.TALK:
                    agent.SetDestination(transform.position);
                    transform.LookAt(villager.position);
                    //anim.SetFloat("Speed", 0f);
                    break;
                default:
                    Debug.Log("Something Went Wrong!");
                    break;
            }

            StartCoroutine("StateChangeDelay");
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

    IEnumerator StateChangeDelay()
    {
        delay = 5f;

        while (delay > 0f)
        {
            delay--;

            yield return new WaitForSeconds(1);
        }
    }
}
