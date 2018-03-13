using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class puzzle2BlockTrigger : MonoBehaviour
{
    puzzle2Manager puz2Manager;
    AudioSource playerAudio;
    [SerializeField] AudioClip wrongAnswer;
    // Got rid of the collider bools as we only need to check for red, green, and blue to see if the puzzle is completed.
    void Start()
    {
        puz2Manager = GameObject.FindGameObjectWithTag("PuzzleManager").GetComponent<puzzle2Manager>();
        playerAudio = GameObject.FindGameObjectWithTag("Player").GetComponent<AudioSource>();
    }
	
    void OnTriggerEnter(Collider other)
    {        
        //checks to make sure the correct object is placed, and then checks to make sure the other puzzles colliders are not triggered
        if (other.tag == "puzzle2Red" && !puz2Manager.GetGreen() && !puz2Manager.GetBlue())
        {
            // sets puzzle manager, red bool to true
            puz2Manager.SetRed(true);

            Debug.Log("Red = true");
        }
        else if (other.tag == "puzzleRed")
        {
            playerAudio.PlayOneShot(wrongAnswer);
        }
        
    }
}
