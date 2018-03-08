using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class puzzle2BlocktriggerC : MonoBehaviour
{   
    // Got rid of the collider bools as we only need to check for red, green, and blue to see if the puzzle is completed.

    void OnTriggerEnter(Collider other)
    {
        //checks to make sure the correct object is placed, and then checks to make sure the other puzzles colliders are not triggered
        if (other.tag == "puzzle2Blue" && puzzle2Manager.GetRed() && puzzle2Manager.GetGreen())
        {
            // sets puzzle manager, blue bool to true
            puzzle2Manager.SetBlue(true);
        }
    }
}
