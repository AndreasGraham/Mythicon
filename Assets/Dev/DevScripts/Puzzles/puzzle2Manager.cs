using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class puzzle2Manager : MonoBehaviour 
{
    // Here I made everything private, but available to set in the editor
    [SerializeField] bool red;
    [SerializeField] bool green;
    [SerializeField] bool blue;
    [SerializeField] bool isAnimComplete;
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
        isAnimComplete = false;
        completionFire.SetActive(false);
        completionObj.SetActive(false);
        completionCam.enabled = false;
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        if(blue && !isAnimComplete) // Took away "= true" as it's not needed
        {
            isAnimComplete = true; // Set that the camera switch "animation" has been played
            completionFire.SetActive(true); // Enable the completion fire
            completionObj.SetActive(true); // Added the completion object to take to the village center stones    
            camManager.ChangeCameras(completionCam); // Change cameras for a "dramatic" showing of the object
            StartCoroutine("CameraDelay"); // Added a delay to see the object for 5 seconds and switch back to the previous camera.
        }
	}

    // Since the bools are now private, I created setters and getters for them. This makes changes to these variables intentional.
    public void SetRed(bool redComplete)
    {
        red = redComplete;
    }

    public bool GetRed()
    {
        return red;
    }

    public void SetBlue(bool blueComplete)
    {
        blue = blueComplete;
    }

    public bool GetBlue()
    {
        return blue;
    }

    public void SetGreen(bool greenComplete)
    {
        green = greenComplete;
    }

    public bool GetGreen()
    {
        return green;
    }

    public void SetAnimComplete(bool isComplete)
    {
        isAnimComplete = isComplete;
    }

    // Coroutine that has the camera delayed before switching back to the previous camera
    IEnumerator CameraDelay()
    {
        

        int counter = 0;
        
        while(counter < 5)
        {
            counter++;
            
            yield return new WaitForSeconds(1);
        }

        camManager.ChangeCameras(camManager.GetPreviousCamera());
    } 
}
