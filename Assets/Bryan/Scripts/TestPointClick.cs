using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TestPointClick : MonoBehaviour 
{
	// Variable to store the RaycastHit data
	RaycastHit hit;
	// Variable to store the Raycast Ray
	Ray ray;
	// NavMeshAgent to be able to use the NavMesh for movement
	NavMeshAgent agent;

	// Use this for initialization
	void Start () 
	{
		// Store the players NavMeshAgent component
		agent = GetComponent<NavMeshAgent>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		// Call the method to move the player on left mouse click
		ClickToMove();
		PickUpObject();
		DropObject();
	}

	// Method to move the player
	void ClickToMove()
	{
		// Check to see if the player clicked the left mouse button
		if (Input.GetMouseButtonDown(0))
		{
			// Cast a ray from the camera to the mouse position
			ray = Camera.main.ScreenPointToRay(Input.mousePosition);

			// Move the player to where the ray hit
			if (Physics.Raycast(ray, out hit, 100f))
			{
				// Put the layer number in a variable
				var hitLayer = hit.collider.gameObject.layer;

				// Switch statement decides by which layer the player moves to
				switch (hitLayer)
				{
					case 8:
						Debug.Log("I Can Walk There!");
						if (agent.stoppingDistance != .5f)
							agent.stoppingDistance = .5f;

						agent.SetDestination(hit.point);
						break;
					case 9:
						Debug.Log("I Can Go To Pick That Up!");
						if (agent.stoppingDistance != 1f)
							agent.stoppingDistance = 1f;

						agent.SetDestination(hit.point);
						break;
					case 10:
						Debug.Log("Ok, I'll Go Drop This!");
						if (agent.stoppingDistance != 1.5f)
							agent.stoppingDistance = 1.5f;

						agent.SetDestination(hit.point);
						break;
					default:
					// TODO: Add Audio or UI telling the player is not a navigable area
						Debug.Log("I Can't Walk There!");
						break;
				}
			}
		}
	}

	void PickUpObject()
	{
		// Check to see if the player clicked the left mouse button
		if (Input.GetMouseButtonDown(0))
		{
			// Cast a ray from the camera to the mouse position
			ray = Camera.main.ScreenPointToRay(Input.mousePosition);

			// Move the player to where the ray hit
			if (Physics.Raycast(ray, out hit, 100f))
			{
				if (hit.collider.gameObject.layer == 9 && Vector3.Distance(transform.position, hit.transform.position) < 2f)
				{
					agent.SetDestination(transform.position);
					hit.transform.GetComponent<Rigidbody>().isKinematic = true;
					hit.transform.parent = transform;
					hit.transform.position = new Vector3(hit.transform.position.x, 1.5f, hit.transform.position.z);
					Debug.Log("You Picked Up The Object!");
				}
			}
		}
	}

	void DropObject()
	{
		// Check to see if the player pressed the left mouse button
		if (Input.GetMouseButtonDown(1))
		{
			// Send a ray from the camera from the mouse position
			Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit mouseHit;

			// ... send a ray from the bottom of the picked up object
			Ray newRay = new Ray();
			newRay.origin = transform.GetChild(0).transform.position;
			newRay.direction = Vector3.down;

			// ... create a new raycast hit data point to use with the newRay
			RaycastHit dropHit;

			// ... get new ray data and the hit point data only on the Dropable_Area layer
			if (Physics.Raycast(newRay, out dropHit, 100f, 1 << 10))
			{
				if (Vector3.Distance(transform.position, dropHit.transform.position) < 3.5f)
				{
					// ... check if the picked up object is over the Dropable_Area
					if (Physics.Raycast(mouseRay, out mouseHit, 100f, 1 << 10))
					{
						if (mouseHit.collider.gameObject == dropHit.collider.gameObject)
						{
							// ... get the picked up objects rigidbody
							var childRB = transform.GetComponentInChildren<Rigidbody>();
							// ... set the isKinematic flag to false so that gravity takes effect
							childRB.isKinematic = false;
							// ... unparent the picked up object from the player character, and reparent to the environment holder gameobject
							childRB.transform.parent = GameObject.FindGameObjectWithTag("Environment Handler").transform; 
						}
					}
				}
			}

		}
	}			
}