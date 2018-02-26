using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine;

public static class SaveLoad
{
    PlayerSaveLoad playerSaveLoad;
    Interactable[] interActableObj;
    EnviroSaveLoad[] enviroObjs;

    public void Save()
    {
        playerSaveLoad = GameObject.FindGameObjectWithTag("Player");
        interActableObj = GameObject.FindGameObjectsWithTag("Interactable");
        enviroObjs = GameObject.FindGameObjectsWithTag("Dropable_Area");


    }
}
