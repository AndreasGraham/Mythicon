using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorCameraTrigger : MonoBehaviour 
{
    CameraManager camManager;
    [SerializeField]
    Camera[] cameras;

    void Awake()
    {
        camManager = GameObject.FindGameObjectWithTag("CameraManager").GetComponent<CameraManager>();
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {   
            if (camManager.GetCurrentCamera() == cameras[0])
                camManager.ChangeCameras(cameras[1]);
            else
                camManager.ChangeCameras(cameras[0]);
        }
    }
}
