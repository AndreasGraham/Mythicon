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
    [SerializeField] GameObject completionObj;
    [SerializeField] Camera completionCam;
    
    CameraManager camManager;

	// Use this for initialization
	void Start ()
    {
        camManager = GameObject.FindGameObjectWithTag("CameraManager").GetComponent<CameraManager>();
        red = false;
        green = false;
        blue = false;
        completionFire.SetActive(false);
        completionObj.SetActive(false);       
	}
	
	// Update is called once per frame
	void Update ()
    {
		if(blue) // Took away "= true" as it's not needed
        {
            completionFire.SetActive(true);
            completionObj.SetActive(true); // Added the completion object to take to the village center stones
            camManager.ChangeCameras(completionCam); // Added a "dramatic" camera change
            StartCoroutine("CameraDelay"); // Added a delay to see the object for 5 seconds and switch back to the previous camera.
        }
	}

    // Since the bools are now private, I created setters and getters for them. This makes changes to these variables intentional.
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

    // Coroutine that has the camera delayed before switching back to the previous camera
    IEnumerator CameraDelay()
    {
        int counter = 0;
        
        while(counter < 6)
        {
            counter++;
            
            yield return new WaitForSeconds(1);
        }

        camManager.ChangeCameras(camManager.GetPreviousCamera());
    } 
}
