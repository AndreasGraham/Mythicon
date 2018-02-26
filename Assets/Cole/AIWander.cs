using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIWander : MonoBehaviour
{
    float Speed = 20;
    Vector3 WayPoint;
    int Range = 10;

	// Use this for initialization
	void Start ()
    {
        Wander();
	}
	
	// Update is called once per frame
	void Update ()
    {
        transform.position += transform.TransformDirection(Vector3.forward) * Speed * Time.deltaTime;

        if ((transform.position - WayPoint).magnitude < 3)
        {
            Wander();
        }

    }

    void Wander()
    {
        //WayPoint = new Vector3(Random.Range(transform.position.x - RangeAttribute, transform.position.x + Range));
    }
}
