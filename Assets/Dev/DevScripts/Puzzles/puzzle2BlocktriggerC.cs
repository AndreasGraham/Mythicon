using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class puzzle2BlocktriggerC : MonoBehaviour {

    
    public static bool colliderTriggerC;
    // Use this for initialization
    void Start () {
        colliderTriggerC = false;
	}
	
	// Update is called once per frame
	void Update () {
        Debug.Log(colliderTriggerC);
    }

    void OnTriggerEnter(Collider other)
    {
        colliderTriggerC = true;
        //checks to make sure the correct object is placed, and then checks to make sure the other puzzles colliders are not triggered
        if (other.tag == "puzzle2Blue" && puzzle2Manager.red == true && puzzle2Manager.green == true)
        {
            // sets puzzle manager, blue bool to true
            puzzle2Manager.SetBlue(true);
            Debug.Log("Blue Trigger True");
            //puzzle2Manager.checkDone();
        }
    }

    void OnTriggerExit(Collider other)
    {
        colliderTriggerC = false;
    }
}
