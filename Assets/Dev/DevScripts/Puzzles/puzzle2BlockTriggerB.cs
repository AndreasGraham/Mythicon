/** Originally Written By: Andreas
 *  Refactored and Rewritten By: Bryan 
 **/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class puzzle2BlockTriggerB : MonoBehaviour
{    
    puzzle2Manager puz2Manager;
    AudioSource playerAudio;

    [Header("Audio")]
    [SerializeField] AudioClip rightAnswer;
    // Got rid of the collider bools as we only need to check for red, green, and blue to see if the puzzle is completed.
    void Start()
    {
        puz2Manager = GameObject.FindGameObjectWithTag("PuzzleManager").GetComponent<puzzle2Manager>();
        playerAudio = GameObject.FindGameObjectWithTag("WrongAudioSource").GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider other)
    {
        //checks to make sure the correct object is placed, and then checks to make sure the other puzzles colliders are not triggered
        if (other.tag == "puzzle2Green" && puz2Manager.GetRed() && !puz2Manager.GetBlue())
        {
            // sets puzzle manager, green bool to true
            puz2Manager.SetGreen(true);
            playerAudio.PlayOneShot(rightAnswer);
        }
        else if (other.tag == "puzzle2Blue" || other.tag == "puzzle2Red")
        {
            playerAudio.PlayOneShot(playerAudio.clip);
        }

    }
}
