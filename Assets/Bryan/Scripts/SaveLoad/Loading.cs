using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loading : MonoBehaviour 
{
    SaveLoad load;

	// Use this for initialization
	void Awake() 
    {
        Time.timeScale = 1;
        load = SaveLoad.Load("Save1");
        if (load.shouldLoad)
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            GameObject camera = GameObject.FindGameObjectWithTag("MainCamera");
            GameObject[] interactableObjs = GameObject.FindGameObjectsWithTag("Interactable");
            GameObject[] enviroObjs = GameObject.FindGameObjectsWithTag("Dropable_Area");

            InteractableObjects[] interactableScripts = new InteractableObjects[interactableObjs.Length];
            for(int k = 0; k < interactableObjs.Length; k++)
            {
                interactableScripts[k] = interactableObjs[k].GetComponent<InteractableObjects>();
            }

            player.transform.position = load.playerPos;
            player.transform.rotation = load.playerRot;
            camera.transform.position = load.cameraPos;
            camera.transform.rotation = load.cameraRot;

            int i = 0;
            foreach (GameObject objs in interactableObjs)
            {
                for (; i < interactableObjs.Length; i++)
                {
                    interactableObjs[i].transform.position = load.interActableObjsPos[i];
                    interactableObjs[i].transform.rotation = load.interactableObjsRot[i];
                    interactableScripts[i].isBeingHeld = load.isInteractableHeld[i];

                    if (interactableScripts[i].isBeingHeld)
                    {
                        interactableObjs[i].GetComponent<Rigidbody>().isKinematic = true;
                        interactableObjs[i].transform.parent = player.transform;
                        player.GetComponent<Animator>().SetBool("isCarrying", true);
                    }
                    else
                        interactableObjs[i].transform.parent = GameObject.FindGameObjectWithTag("Environment Handler").transform;

                    break;
                }

                i++;
            }
        }
	}
}
