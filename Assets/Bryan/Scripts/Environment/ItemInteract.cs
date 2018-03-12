using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInteract : MonoBehaviour 
{
    ItemCounter count;
    PlayerAnimation anim;
    CameraManager camManager;
    FirstPuzzle firstPuzzle;
    GameObject swordCollect;
    GameObject staffCollect;
    GameObject shieldCollect;

    Ray ray;
    RaycastHit hit;

	// Use this for initialization
	void Start () 
    {
        count = Camera.main.GetComponent<ItemCounter>();
        anim = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerAnimation>();
        camManager = GameObject.FindGameObjectWithTag("CameraManager").GetComponent<CameraManager>();
        firstPuzzle = GameObject.FindGameObjectWithTag("PuzzleManager").GetComponent<FirstPuzzle>();
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
                Debug.Log("Item Collected");

                switch (hit.collider.name)
                {
                    case "Rune Sword":
                        firstPuzzle.SetSwordActive(false);
                        break;
                    case "shield":
                        firstPuzzle.SetShieldActive(false);
                        break;
                    case "staff":
                        firstPuzzle.SetStaffActive(false);
                        break;
                    default:
                        break;
                }
            }
            else if (hit.collider.gameObject.tag == "Flowers")
            {
                CollectItem(2);
            }
        }

	}

    void CollectItem(int noOfItems)
    {
        ray = camManager.GetCurrentCamera().ScreenPointToRay(Input.mousePosition);

            if (hit.collider.gameObject.layer == 12 && Vector3.Distance(transform.position, hit.transform.position) < 1f)
            {
                anim.SetIsPickingUp(true);
                count.SetItem(noOfItems);
            }

        if(anim.GetIsPickingUp())
            anim.SetIsPickingUp(false);

        /** TODO: Figure out how to get into staff house!!! **/
    }
}
