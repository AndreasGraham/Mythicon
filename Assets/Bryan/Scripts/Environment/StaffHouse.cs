using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaffHouse : MonoBehaviour 
{
    [SerializeField]
    Collider[] houseColliders;

    CameraManager camManager;
    Camera mainCamera;

	// Use this for initialization
	void Start () 
    {
        camManager = GameObject.FindGameObjectWithTag("CameraManager").GetComponent<CameraManager>();
        mainCamera = Camera.main.GetComponent<Camera>();
	}
	
	// Update is called once per frame
	void FixedUpdate () 
    {
        if (camManager.GetCurrentCamera() == GameObject.Find("Downstairs Entry Staff Camera") && houseColliders[0].enabled)
        {
            EnableDisable();
        }

        if(!mainCamera.enabled)
        {
            if (!houseColliders[0].enabled)
            {
                EnableDisable();
            }
        }
	}

    void EnableDisable()
    {
        foreach (Collider h in houseColliders)
        {
            h.enabled = !h.enabled;
        }
    }
}
