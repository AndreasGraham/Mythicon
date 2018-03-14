using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour 
{
	// Variable to store the RaycastHit data
	RaycastHit hit;
	// Variable to store the Raycast Ray
	Ray ray;
	// NavMeshAgent to be able to use the NavMesh for movement
	NavMeshAgent agent;

    CameraManager camManager;

    [SerializeField]
    GameObject[] children = new GameObject[6];

    [SerializeField]
    Vector3 heldPosition;
    [SerializeField]
    Transform heldParent;
    PlayerAnimation animations;
    Vector3 hitPoint;
    GameObject heldItem;

    [SerializeField]
    private bool isInteractive;

	// Use this for initialization
	void Start () 
	{
		// Store the players NavMeshAgent component
		agent = GetComponent<NavMeshAgent>();

        animations = GetComponent<PlayerAnimation>();

        isInteractive = false;

        camManager = GameObject.FindGameObjectWithTag("CameraManager").GetComponent<CameraManager>();
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
        // Call the method to move the player on left mouse click
		ClickToMove();

        if (Vector3.Distance(transform.position, ClickToMove()) < .5f)
            animations.SetWalkSpeed(0f);
		PickUpObject();
		DropObject();
	}

    // Check to see if the player is in an interactable area
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "InteractableArea")
        {
            isInteractive = true;
        }
    }

    // Check to see if the player has left an interactable area
    void OnTriggerExit(Collider other)
    {
        if (other.tag == "InteractableArea")
            isInteractive = false;
    }

    // Return if the player is in an interactable area or not
    public bool GetInInteractiveArea()
    {
        return isInteractive;
    }

	// Method to move the player
	Vector3 ClickToMove()
	{
		// Check to see if the player clicked the left mouse button
		if (Input.GetMouseButtonDown(0))
		{
			// Cast a ray from the camera to the mouse position
            ray = camManager.GetCurrentCamera().ScreenPointToRay(Input.mousePosition);

			// Move the player to where the ray hit
			if (Physics.Raycast(ray, out hit, 100f))
			{
				// Put the layer number in a variable
				var hitLayer = hit.collider.gameObject.layer;
                hitPoint = hit.point;
				// Switch statement decides by which layer the player moves to
				switch (hitLayer)
				{
                    case 8:
                        if (agent.stoppingDistance != 1.5f)
                            agent.stoppingDistance = 1.5f;

                        if (Vector3.Distance(transform.position, hit.point) < 1f)
                        {
                            agent.SetDestination(transform.position);
                            transform.LookAt(hit.point);
                        }
                        else
                        {
                            agent.SetDestination(hit.point);
                            animations.SetWalkSpeed(1f);
                        }
                        break;
                    case 9:
                    case 14:
                        if (agent.stoppingDistance != 1.75f)
                            agent.stoppingDistance = 1.75f;

                        if (Vector3.Distance(transform.position, hit.point) < 2f)
                        {
                            agent.SetDestination(transform.position);
                            transform.LookAt(hit.point);
                        }
                        else
                        {
                            agent.SetDestination(hit.point);
                            animations.SetWalkSpeed(1f);
                        }
						break;
                    case 10:
                        if (agent.stoppingDistance != 1.5f)
                            agent.stoppingDistance = 1.5f;

                        if (Vector3.Distance(transform.position, hit.point) < 2f)
                        {
                            agent.SetDestination(transform.position);
                            transform.LookAt(hit.point);
                        }
                        else
                        {
                            agent.SetDestination(hit.point);
                            animations.SetWalkSpeed(1f);
                        }
						break;
					default:
					// TODO: Add Audio or UI telling the player is not a navigable area
						Debug.Log("I Can't Walk There!");
						break;
				}


			}
		}
        return hitPoint;
	}

	void PickUpObject()
	{
		// Check to see if the player clicked the left mouse button
		if (Input.GetMouseButtonDown(0))
		{            
			// Cast a ray from the camera to the mouse position
            ray = camManager.GetCurrentCamera().ScreenPointToRay(Input.mousePosition);

			// Move the player to where the ray hit
			if (Physics.Raycast(ray, out hit, 100f))
			{				
                if (hit.collider.gameObject.layer == 14 && Vector3.Distance(transform.position, hit.transform.position) < 2f)
				{
                    Debug.Log(transform.forward);
                    heldPosition = Vector3.zero;                
                    heldPosition = new Vector3(0f, 0f, .2f);
                    hit.transform.parent = transform;
                    hit.transform.rotation = new Quaternion(0f, 0f, 0f, 0f);
                    hit.transform.GetComponent<Rigidbody>().isKinematic = true;

                    heldPosition.y = (transform.lossyScale.y / 2f);
                    hit.transform.localPosition = heldPosition;
                    heldItem = hit.transform.gameObject;
                    heldParent = hit.transform.parent;
                    
                    animations.SetIsCarrying(true);
				}
			}
		}
	}
    
	void DropObject()
	{
        // Check to see if the player pressed the left mouse button
		if (Input.GetMouseButtonDown(1))
		{
            animations.SetIsCarrying(false);
            
            foreach(GameObject child in children)
            {
                if(child.transform.parent == gameObject.transform)
                {
                    child.GetComponent<Rigidbody>().isKinematic = false;
                    child.transform.parent = null;
                }
            }
        }
	}			
}