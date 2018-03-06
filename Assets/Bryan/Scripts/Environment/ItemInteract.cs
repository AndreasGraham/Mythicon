using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInteract : MonoBehaviour 
{
    ItemCounter count;
    PlayerAnimation anim;

    Ray ray;
    RaycastHit hit;

	// Use this for initialization
	void Start () 
    {
        count = Camera.main.GetComponent<ItemCounter>();
        anim = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerAnimation>();
	}
	
	// Update is called once per frame
	void FixedUpdate () 
    {
        CollectItem();
	}

    void CollectItem()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (hit.collider.gameObject.layer == 12 && Vector3.Distance(transform.position, hit.transform.position))
            {
                anim.SetIsPickingUp(true);
                count.SetItem(2);
            }

            anim.SetIsPickingUp(false);
        }
    }
}
