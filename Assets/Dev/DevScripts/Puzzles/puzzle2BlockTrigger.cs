using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class puzzle2BlockTrigger : MonoBehaviour {
    // the first puzzle trigger


    // tracks if any object is in the placement space
    [SerializeField]
    public static bool colliderTriggerA;
	// Use this for initialization
	void Start () {
        colliderTriggerA = false;
	}
	
	// Update is called once per frame
	void Update () {
        //Debug.Log(colliderTriggerA);
    }

    void OnTriggerEnter(Collider other)
    {
        // indication that an object, correct or incorrect, has been placed
        colliderTriggerA = true;
        //checks to make sure the correct object is placed, and then checks to make sure the other puzzles colliders are not triggered
        if(other.tag == "puzzle2Red" && puzzle2BlockTriggerB.colliderTriggerB == false && puzzle2BlocktriggerC.colliderTriggerC == false)
        {
            // sets puzzle manager, red bool to true
            puzzle2Manager.SetRed(true);
            Debug.Log("Red Triggered" + puzzle2Manager.red);
        }
        
    }
    
    void OnTriggerExit(Collider other)
    {
        colliderTriggerA = false;
    }
}
//gunna need flags as fuck from each block 