using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DevMenuLoad : MonoBehaviour 
{
    DevSaveLoad load;

    void Start()
    {
        load = DevSaveLoad.Load("Save1");

        if (load.shouldLoad)
        {
            load.shouldLoad = false;
            load.Save("Save1");
        }
    }
	
}
