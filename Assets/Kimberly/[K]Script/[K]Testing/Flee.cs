using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flee : MonoBehaviour
{
    Vector3 desiredVelocity;
    public float speed;
    public Transform target;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        desiredVelocity = -speed * (target.position - transform.position).normalized;
    }

    public Vector3 returnFlee()
    {
        return (target.position - transform.position) * -1 + transform.position;
    }
}