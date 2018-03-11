using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleManager : MonoBehaviour 
{
    FirstPuzzle firstPuzzle;
    [SerializeField]
    Camera swordCam;
    CameraManager camManager;
	// Use this for initialization
	void Awake() 
    {
        firstPuzzle = GameObject.FindGameObjectWithTag("PuzzleManager").GetComponent<FirstPuzzle>();
        camManager = GameObject.FindGameObjectWithTag("CameraManager").GetComponent<CameraManager>();
    }
	
	// Update is called once per frame
	void Update () 
    {
        if (firstPuzzle.GetPuzzleComplete() && !firstPuzzle.GetAnimationPlayed())
        {
            firstPuzzle.SetAnimationPlayed(true);
            camManager.ChangeCameras(swordCam);            
            StartCoroutine("CameraDelay");
        }
	}

    IEnumerator CameraDelay()
    {
        int sec = 0;

        while (sec < 6)
        {
            sec++;

            yield return new WaitForSeconds(1);
        }

        camManager.ChangeCameras(camManager.GetPreviousCamera());
    }
}
