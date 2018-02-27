using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestUI : MonoBehaviour 
{
    [SerializeField] Text instructionText;
    [SerializeField] GameObject bush;

    bool isPickedUp;
    bool isTutOver;

	// Use this for initialization
	void Start () 
    {
        isPickedUp = false;
        isTutOver = false;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Vector3.Distance(transform.position, bush.transform.position) < 1f)
        {
            instructionText.text = "Right Click On The Bush To Pick The Berries";
            isTutOver = true;
        }

        if (!isTutOver)
        {
            instructionText.text = "Left Click To Walk To The Bush";
        }

        if (isTutOver)
            instructionText.enabled = false;
    }
}
