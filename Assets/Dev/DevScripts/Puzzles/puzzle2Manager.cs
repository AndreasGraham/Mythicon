using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class puzzle2Manager : MonoBehaviour 
{
    // Here I made everything private, but available to set in the editor
    [SerializeField] static bool red;
    [SerializeField] static bool green;
    [SerializeField] static bool blue;
    [SerializeField] GameObject completionFire;

	// Use this for initialization
	void Start ()
    {
        red = false;
        green = false;
        blue = false;
        completionFire.SetActive(false);       
	}
	
	// Update is called once per frame
	void Update ()
    {
		if(blue) // Took away "= true" as it's not needed
        {
            completionFire.SetActive(true);
        }
	}

    // Since the bools are now private, I created setters and getters for them.
    public static void SetRed(bool redComplete)
    {
        red = redComplete;
    }

    public static bool GetRed()
    {
        return red;
    }

    public static void SetBlue(bool blueComplete)
    {
        blue = blueComplete;
    }

    public static bool GetBlue()
    {
        return blue;
    }

    public static void SetGreen(bool greenComplete)
    {
        green = greenComplete;
    }

    public static bool GetGreen()
    {
        return green;
    }
}
