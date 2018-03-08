using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPuzzle : MonoBehaviour 
{
    // All of the items needed for the puzzle
    /** I made all of the variables private and serialized them to
        treat them as if they were public. However, because they are
        private they can't be accessed out of the class, and another
        programmer can't access them unintentionally. This is encapsulation,
        it's used to keep data safe. I almost never put anything as public.
    **/
    [SerializeField] GameObject sword;
    [SerializeField] GameObject shield;
    [SerializeField] GameObject staff;
    [SerializeField] GameObject clanSword;
    [SerializeField] GameObject fireOne;
    [SerializeField] GameObject fireTwo;
    [SerializeField] GameObject fireThree;
    [SerializeField] GameObject clanFire;

    bool puzzleCompletion;
    bool animationPlayed; // I added this to be able to know when to go back to the previous camera

	// Use this for initialization
	void Start () 
    {
        puzzleCompletion = false;
        animationPlayed = false;
        clanFire.SetActive(false);
        clanSword.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () 
    {
        // I changed all of the "= false" statements in the if's so they're more astheically pleasing to read.
		if(!sword.activeSelf)
        {
            fireOne.SetActive(true);
        }
        if(!shield.activeSelf)
        {
            fireTwo.SetActive(true);
        }
        if(!staff.activeSelf)
        {
            fireThree.SetActive(true);
        }

        if(!sword.activeSelf && !shield.activeSelf && !staff.activeSelf)
        {
            clanFire.SetActive(true);
            clanSword.SetActive(true);
            puzzleCompletion = true;
        }
	}

    // Since I put everthing as private I had to make getters and setters in.
    // Another way to ensure that the other programmers intended to manipulate
    // your variables.
    public bool GetPuzzleComplete()
    {
        return puzzleCompletion;
    }

    public bool GetAnimationPlayed()
    {
        return animationPlayed;
    }

    public void SetAnimationPlayed(bool isPlayed)
    {
        animationPlayed = isPlayed;
    }
}
