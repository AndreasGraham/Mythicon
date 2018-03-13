using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class puzzle2BlocktriggerC : MonoBehaviour
{   
    puzzle2Manager puz2Manager;
    AudioSource playerAudio;
    [SerializeField] AudioClip wrongAnswer;
    // Got rid of the collider bools as we only need to check for red, green, and blue to see if the puzzle is completed.
    void Start()
    {
        puz2Manager = GameObject.FindGameObjectWithTag("PuzzleManager").GetComponent<puzzle2Manager>();   
    }

    void OnTriggerEnter(Collider other)
    {
        //checks to make sure the correct object is placed, and then checks to make sure the other puzzles colliders are not triggered
        if (other.tag == "puzzle2Blue" && puz2Manager.GetRed() && puz2Manager.GetGreen())
        {
            // sets puzzle manager, blue bool to true
            puz2Manager.SetBlue(true);
        }
        else if (other.tag == "puzzle2Red" || other.tag == "puzzle2Blue")
        {
            playerAudio.PlayOneShot(wrongAnswer);
        }
    }
}
