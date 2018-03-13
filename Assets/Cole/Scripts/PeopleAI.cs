using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

enum AIState {Walk, Talk};
public class PeopleAI : MonoBehaviour
{
    private Transform Target;
    private NavMeshAgent Agent;
    private float Delay;
    private Transform Villager = null;
    private Animator anim;
    [SerializeField] private AIState States;
    [SerializeField] private float wanderRadius;


    // Use this for initialization
    void Start()
    {
        Agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        anim.SetFloat("Speed", 1f);
        States = AIState.Walk;
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 ray = transform.position;
        ray.y = transform.lossyScale.y / 2f;
        RaycastHit hit;
      
        if (Physics.SphereCast(ray, 1f, transform.forward, out hit, 1f))
        {
            Debug.DrawRay(transform.position, transform.forward, Color.green);
            if (hit.collider.tag == "Villager" && States == AIState.Walk)
            {
                Villager = hit.transform;
                States = AIState.Talk;
            }
            else if (Villager != null && States == AIState.Talk)
            {
                Villager = null;
                States = AIState.Walk;
            }
        }


        if (Delay <= 0f)
        {
            switch (States)
            {
                case AIState.Walk:
                    Vector3 newPos = RandomNavMesh(transform.position, wanderRadius, -1);
                    anim.SetFloat("Speed", 1f);
                    Agent.SetDestination(newPos);
                    break;
                case AIState.Talk:
                    Agent.SetDestination(transform.position);
                    anim.SetFloat("Speed", 0f);
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
       
        Delay = 7f;

        while (Delay > 0f)
        {
            Delay--;

            yield return new WaitForSeconds(1);
        }
    }

}
