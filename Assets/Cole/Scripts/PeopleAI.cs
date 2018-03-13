using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

enum states {Walk, Talk};
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
    private Animator anim;

    states AIStates;

    // Use this for initialization
    void Start()
    {
        Agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        wanderTimer = timeToWander;
        AIStates = states.Walk;
    }

    // Update is called once per frame
    void Update()
    {

        if(Vector3.Distance(transform.position, Villager.position) < 3f)
        {
            AIStates = states.Talk;
        }
        switch (AIStates)
        {
            case states.Talk:
                transform.LookAt(Villager.transform);
                Agent.SetDestination(transform.position);
                anim.SetFloat("Speed", 0f);
                break;

            case states.Walk:
                Vector3 newPos = RandomNavMesh(transform.position, WanderRadius, -1);
                Agent.SetDestination(newPos);
                anim.SetFloat("Speed", 1f);
                break;
        }
    //    wanderTimer += 5;
    //    talkTimer += Time.deltaTime;

    //    if (wanderTimer >= timeToWander && Villager == null)
    //    {
    //        Vector3 newPos = RandomNavMesh(transform.position, WanderRadius, -1);
    //        Agent.SetDestination(newPos);
    //        anim.SetFloat("Speed", 1f);
    //        wanderTimer = 0;
    //    }

    //    if (Villager == null && talkTimer >= timeToTalk)
    //    {
    //        Villager = GameObject.FindGameObjectWithTag("Villager").transform;
    //        talkTimer = 0;
           
    //    }
    //    if(Villager != null && talkTimer >= 5)
    //    {
    //        Villager = null;
    //        anim.SetFloat("Speed", 0f);
    //    }

    //    if(Villager != null)
    //    {
    //        Agent.destination = Villager.position;
    //        anim.SetFloat("Speed", 1f);
    //    }

    }
    void WalkToTalk()
    {
        if (talkTimer <= 0)
        {
            AIStates = states.Walk;
        }
    }

    IEnumerator TalkDelay()
    {
        talkTimer = 7;
        while(talkTimer > 0)
        {
            talkTimer--;
            yield return new WaitForSeconds(1);
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
