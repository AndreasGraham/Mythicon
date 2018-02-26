using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Interactable : MonoBehaviour 
{
    //NavMeshObstacle obstacle;

	// Use this for initialization
	void Start () 
    {
        //obstacle = GetComponent<NavMeshObstacle>();
	}

    void OnCollisionEnter(Collision other)
    {
        //if (other.collider.tag == "Dropable_Area")
            //obstacle.enabled = true;
    }
}
