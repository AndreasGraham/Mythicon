using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SaveLoadWrapper :  MonoBehaviour
{
    SaveLoad saveLoad1 = new SaveLoad();

    void Awake()
    {
        saveLoad1.playerPosScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerSaveLoad>();
        saveLoad1.playerPos = GameObject.FindGameObjectWithTag("Player").transform.position;
        saveLoad1.interactableObjs = GameObject.FindGameObjectsWithTag("Interactable");
    }

    public void Save(string playerSaveName)
    {
        int i = 0;
        
        if(saveLoad1.interActableObjsPos.Length == 0)
            saveLoad1.interActableObjsPos = new Vector3[saveLoad1.interactableObjs.Length];
        if(saveLoad1.interactableObjsRot.Length == 0)
            saveLoad1.interactableObjsRot = new Quaternion[saveLoad1.interactableObjs.Length];
        if(saveLoad1.interactableObjsPosScript.Length == 0)
            saveLoad1.interactableObjsPosScript = new InteractableObjects[saveLoad1.interactableObjs.Length];
        if(saveLoad1.isInteractableHeld.Length == 0)
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
        saveLoad1.Save(playerSaveName);
    }

    public void Load(string playerSaveName)
    {
        
        saveLoad1 = SaveLoad.Load(playerSaveName);
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        GameObject[] interactableObjs = GameObject.FindGameObjectsWithTag("Interactable");
        GameObject[] enviroObjs = GameObject.FindGameObjectsWithTag("Dropable_Area");

        InteractableObjects[] interactableScripts = new InteractableObjects[interactableObjs.Length];
        for(int k = 0; k < interactableObjs.Length; k++)
        {
            interactableScripts[k] = interactableObjs[k].GetComponent<InteractableObjects>();
        }

        player.transform.position = saveLoad1.playerPos;
        player.GetComponent<NavMeshAgent>().SetDestination(player.transform.position);

        int i = 0;
        foreach (GameObject objs in interactableObjs)
        {
            for (; i < interactableObjs.Length; i++)
            {
                interactableObjs[i].transform.position = saveLoad1.interActableObjsPos[i];
                interactableObjs[i].transform.rotation = saveLoad1.interactableObjsRot[i];
                interactableScripts[i].isBeingHeld = saveLoad1.isInteractableHeld[i];

                if (interactableScripts[i].isBeingHeld)
                {
                    interactableObjs[i].GetComponent<Rigidbody>().isKinematic = true;
                    interactableObjs[i].transform.parent = player.transform;

                }
                else
                    interactableObjs[i].transform.parent = GameObject.FindGameObjectWithTag("Environment Handler").transform;

                break;
            }

            i++;
        }

   }
}
