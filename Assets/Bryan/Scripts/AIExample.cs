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
    [SerializeField] private AIStates states;
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
        // Create a position of origin for the SphereCast
        Vector3 ray = transform.position;
        // Set the y pos to the middle of the NPC
        ray.y = transform.lossyScale.y / 2f;
        // Create a hit to get the information out of the raycast
        RaycastHit hit;

        // Shoot the SphereCast using the information above
        if (Physics.SphereCast(ray, 1f, transform.forward, out hit, 1f))
        {
            // If the SphereCast hits a villager and the state is walk...
            if (hit.collider.tag == "Villager" && states == AIStates.WALK)
            {
                // Set the villager to the transform of the hit gameobject...
                villager = hit.transform;
                // Set the state to talk
                states = AIStates.TALK;
            }
            // Otherwise we switch from talking to walking...
            else if(villager != null && states == AIStates.TALK)
            {
                // Set the villager to null
                villager = null;
                // Set the state to walk
                states = AIStates.WALK;
            }            
        }
        // Ensure that we've been in the current state long enough
        if (delay <= 0f)
        {
            // If we have been in it long enough we switch states
            switch (states)
            {
                // The walk state wanders and sets the animation to the walk animation
                case AIStates.WALK:
                    Vector3 newPos = RandomNavMesh(transform.position, wanderRadius, -1);
                    agent.SetDestination(newPos);
                    //anim.SetFloat("Speed", 1f);
                    break;
                // The talk state ensures the NPC doesn't move and sets the animation to the idle animation
                case AIStates.TALK:
                    agent.SetDestination(transform.position);
                    //anim.SetFloat("Speed", 0f);
                    break;
                default:
                    Debug.Log("Something Went Wrong!");
                    break;
            }

            // The coroutine starts the state change delay
            StartCoroutine("StateChangeDelay");
        }
    }

    // The wander logic
    public static Vector3 RandomNavMesh(Vector3 origin, float dist, int layermask)
    {

        Vector3 randDirection = Random.insideUnitSphere * dist;

        randDirection += origin;

        NavMeshHit navHit;

        NavMesh.SamplePosition(randDirection, out navHit, dist, layermask);

        return navHit.position;
    }

    // The IEnumerator that ensures that our delay for the state changes are correct
    IEnumerator StateChangeDelay()
    {
        // I found this to be an optimal time where the NPC's don't get stuck in a state as often
        delay = 7f;

        while (delay > 0f)
        {
            delay--;

            yield return new WaitForSeconds(1);
        }
    }
}
