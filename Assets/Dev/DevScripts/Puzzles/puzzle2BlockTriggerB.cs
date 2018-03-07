using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class puzzle2BlockTriggerB : MonoBehaviour {
    
    public static bool colliderTriggerB;
    // Use this for initialization
    void Start () {
        colliderTriggerB = false;
	}
	
	// Update is called once per frame
	void Update () {
        //Debug.Log(colliderTriggerB);
    }

    //void OnTriggerEnter(Collider other)
    //{
    //    colliderTriggerB = true;
    //    //checks to make sure the correct object is placed, and then checks to make sure the other puzzles colliders are not triggered
    //    if (other.tag == "puzzle2Green" && puzzle2Manager.red == true && puzzle2BlocktriggerC.colliderTriggerC == false)
    //    {
    //        // sets puzzle manager, red bool to true
    //        puzzle2Manager.green = true;
    //    }
    //}

    void OnTriggerEnter(Collider other)
    {
        
        colliderTriggerB = true;
        //checks to make sure the correct object is placed, and then checks to make sure the other puzzles colliders are not triggered
        if (other.tag == "puzzle2Green" && puzzle2Manager.red == true && puzzle2BlocktriggerC.colliderTriggerC == false)
        {
            // sets puzzle manager, green bool to true
            puzzle2Manager.SetGreen(true);
            Debug.Log("Green Trigger True");
           // puzzle2Manager.checkDone();
        }

    }

    void OnTriggerExit(Collider other)
    {
        colliderTriggerB = false;
    }

}
