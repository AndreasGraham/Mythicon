using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInteract : MonoBehaviour 
{
    ItemCounter count;
    PlayerAnimation anim;
    CameraManager camManager;

    Ray ray;
    RaycastHit hit;

	// Use this for initialization
	void Start () 
    {
        count = Camera.main.GetComponent<ItemCounter>();
        anim = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerAnimation>();
        camManager = GameObject.FindGameObjectWithTag("CameraManager").GetComponent<CameraManager>();
	}
	
	// Update is called once per frame
	void FixedUpdate () 
    {
        ray = camManager.GetCurrentCamera().ScreenPointToRay(Input.mousePosition);
            
        if (Physics.Raycast(ray, out hit, 200f) && Input.GetMouseButtonDown(0))
        {
            if (hit.collider.gameObject.tag == "Collectable")
            {
                CollectItem(1);
                gameObject.SetActive(false);
            }
            else if (hit.collider.gameObject.tag == "Flowers")
            {
                CollectItem(2);
            }
        }

	}

    void CollectItem(int noOfItems)
    {
        if (hit.collider.gameObject.layer == 12 && Vector3.Distance(transform.position, hit.transform.position) < 1f)
        {
<<<<<<< HEAD
            anim.SetIsPickingUp(true);
            count.SetItem(noOfItems);
        }
=======
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (hit.collider.gameObject.layer == 12 && Vector3.Distance(transform.position, hit.transform.position) < 1f)
            {
                anim.SetIsPickingUp(true);
                count.SetItem(2);
            }
>>>>>>> 5d4f98721e48ced15b9f184aee39b2eef024003d

        if(anim.GetIsPickingUp())
            anim.SetIsPickingUp(false);
    }
}
