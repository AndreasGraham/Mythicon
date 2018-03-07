using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class SaveLoadWrapper :  MonoBehaviour
{
    SaveLoad saveLoad1 = new SaveLoad();

    public void Save()
    {
        int i = 0;

        saveLoad1.playerPosScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerSaveLoad>();
        saveLoad1.playerPos = GameObject.FindGameObjectWithTag("Player").transform.position;
        saveLoad1.playerRot = GameObject.FindGameObjectWithTag("Player").transform.rotation;
        saveLoad1.cameraPos = GameObject.FindGameObjectWithTag("MainCamera").transform.position;
        saveLoad1.cameraRot = GameObject.FindGameObjectWithTag("MainCamera").transform.rotation;
        saveLoad1.interactableObjs = GameObject.FindGameObjectsWithTag("Interactable");

        saveLoad1.interActableObjsPos = new Vector3[saveLoad1.interactableObjs.Length];
        saveLoad1.interactableObjsRot = new Quaternion[saveLoad1.interactableObjs.Length];
        saveLoad1.interactableObjsPosScript = new InteractableObjects[saveLoad1.interactableObjs.Length];
        saveLoad1.isInteractableHeld = new bool[saveLoad1.interactableObjs.Length];

        foreach (GameObject objs in saveLoad1.interactableObjs)
        {
            for (; i < saveLoad1.interactableObjs.Length; i++)
            {
                saveLoad1.interactableObjsPosScript[i] = saveLoad1.interactableObjs[i].GetComponent<InteractableObjects>();
                saveLoad1.interActableObjsPos[i] = saveLoad1.interactableObjsPosScript[i].objectPos;
                saveLoad1.interactableObjsRot[i] = saveLoad1.interactableObjsPosScript[i].objectRot;
                saveLoad1.isInteractableHeld[i] = saveLoad1.interactableObjsPosScript[i].isBeingHeld;
                break;
            }

            i++;
        }

        saveLoad1.enviroObjs = GameObject.FindGameObjectsWithTag("Dropable_Area");
        saveLoad1.playerPos = saveLoad1.playerPosScript.playerPos;
        saveLoad1.playerRot = saveLoad1.playerPosScript.playerRot;
        saveLoad1.sceneIndex = saveLoad1.playerPosScript.sceneIndex;
        saveLoad1.shouldLoad = false;
        saveLoad1.Save("Save1");
    }

    public void Load()
    {
        saveLoad1 = SaveLoad.Load("Save1");
        saveLoad1.shouldLoad = true;
        saveLoad1.Save("Save1");
        SceneManager.LoadScene(saveLoad1.sceneIndex);
   }
}
