using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPuzzle : MonoBehaviour {
    public GameObject sword;
    public GameObject shield;
    public GameObject staff;
    public GameObject clanSword;
    public GameObject fireOne;
    public GameObject fireTwo;
    public GameObject fireThree;
    public GameObject clanFire;

    bool puzzleCompletion;

	// Use this for initialization
	void Start () {
        puzzleCompletion = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(sword.activeSelf == false)
        {
            fireOne.SetActive(true);
        }
        if(shield.activeSelf == false)
        {
            fireTwo.SetActive(true);
        }
        if(staff.activeSelf == false)
        {
            fireThree.SetActive(true);
        }

        if(sword.activeSelf == false && shield.activeSelf == false && staff.activeSelf == false)
        {
            clanFire.SetActive(true);
            clanSword.SetActive(true);
            puzzleCompletion = true;
        }
	}
}
