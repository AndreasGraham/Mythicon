using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class AIFlee : MonoBehaviour
{

    Rigidbody rb;
    Rigidbody taggerRb;
    Vector3 desiredVelocity;
    Vector3 projectedPosition;
    public float speed;
    public float projectedDistance;
    public float currentSpeed;
    public float evadeRange;
    //float EvadeDist;
    NavMeshAgent agent;
    public Transform target;
    // Use this for initialization
    void Start()
    {
        
        agent = GetComponent<NavMeshAgent>();
        rb = GetComponent<Rigidbody>();
        taggerRb = target.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float dist = Vector3.Distance(target.position, transform.position);
        if (dist < evadeRange)
        {
            projectedPosition = target.position + (taggerRb.velocity.normalized * projectedDistance);
            desiredVelocity = currentSpeed * (projectedPosition - transform.position).normalized;
            //rb.AddForce(desiredVelocity - rb.velocity);
            agent.destination = transform.position + desiredVelocity.normalized;
        }
        else
        {
           //Do Wander stuff
        }
    }
}