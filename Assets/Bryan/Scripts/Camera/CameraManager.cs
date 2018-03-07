using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour 
{
    [SerializeField]
    private Camera currentCamera;

	// Use this for initialization
	void Start () 
    {
        currentCamera = Camera.main.GetComponent<Camera>();
	}

    public void ChangeCameras(Camera newCamera)
    {
        
        newCamera.enabled = true;
        currentCamera.enabled = false;
        currentCamera.gameObject.GetComponent<AudioListener>().enabled = false;
        if (!newCamera.gameObject.GetComponent<AudioListener>().enabled)
            newCamera.gameObject.GetComponent<AudioListener>().enabled = true;
        
        currentCamera = newCamera;
    }

    public Camera GetCurrentCamera()
    {
        return currentCamera;
    }
}
