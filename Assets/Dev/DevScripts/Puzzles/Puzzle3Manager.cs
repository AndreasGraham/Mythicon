using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Puzzle3Manager : MonoBehaviour
{
    [SerializeField] GameObject[] buttons;
    [SerializeField] Camera completionCam;
    [SerializeField] GameObject completionObj;
    [SerializeField] GameObject completionFire;
    [SerializeField] bool isCyanPushed;
    [SerializeField] bool isMagentaPushed;
    [SerializeField] bool isYellowPushed;
    [SerializeField] bool isKeyPushed;
    [SerializeField] bool isAnimComplete;

    GameObject player;
    CameraManager camManager;
    Ray ray;
    RaycastHit hit;

	// Use this for initialization
	void Start ()
    {
        camManager = GameObject.FindGameObjectWithTag("CameraManager").GetComponent<CameraManager>();
        player = GameObject.FindGameObjectWithTag("Player");
        isCyanPushed = isMagentaPushed = isYellowPushed = isKeyPushed = isAnimComplete = false;
        completionCam.enabled = false;
        completionObj.SetActive(false);
        completionFire.SetActive(false);
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        ray = camManager.GetCurrentCamera().ScreenPointToRay(Input.mousePosition);

        if(Physics.Raycast(ray, out hit, 100f))
        {
            float dist = Vector3.Distance(player.transform.position, hit.collider.transform.position);

            switch(hit.collider.tag)
            {
                case "CyanButton":
                    if(dist < 2f)
                    isCyanPushed = true;
                    break;
                case "MagentaButton":
                    if (isCyanPushed && dist < 2f)
                        isMagentaPushed = true;
                    break;
                case "YellowButton":
                    if (isMagentaPushed && dist < 2f)
                        isYellowPushed = true;
                    break;
                case "KeyButton":
                    if (isYellowPushed && dist < 2f)
                        isKeyPushed = true;
                    break;
                default:
                    break;
            }
        }

        if(isKeyPushed && !isAnimComplete)
        {
            isAnimComplete = true;
            completionFire.SetActive(true);
            completionObj.SetActive(true);
            camManager.ChangeCameras(completionCam);
            StartCoroutine("CameraDelay");
        }
	}

    IEnumerator CameraDelay()
    {
        int delay = 0;

        while(delay < 5)
        {
            delay++;

            yield return new WaitForSeconds(1);
        }

        camManager.ChangeCameras(camManager.GetPreviousCamera());
    }
}
