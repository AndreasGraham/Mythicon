using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class puzzle2Manager : MonoBehaviour {
    public static bool red;
    public static bool green;
    public static bool blue;
    public GameObject completionFire;
	// Use this for initialization
	void Start () {
        red = false;
        green = false;
        blue = false;
        completionFire.SetActive(false);
       
	}
	
	// Update is called once per frame
	void Update () {
        //Debug.Log(blue);
		if(blue == true)
        {
            completionFire.SetActive(true);
        }
	}

    /*public static void checkDone()
    {
        if (blue == true)
        {
            completionFire.SetActive(true);
        }
    }*/

}
