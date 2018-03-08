using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class puzzle2BlockTrigger : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        // indication that an object, correct or incorrect, has been placed
        
        //checks to make sure the correct object is placed, and then checks to make sure the other puzzles colliders are not triggered
        if(other.tag == "puzzle2Red" && !puzzle2Manager.GetGreen() && !puzzle2Manager.GetBlue())
        {
            // sets puzzle manager, red bool to true
            puzzle2Manager.SetRed(true);
        }
        
    }
}
