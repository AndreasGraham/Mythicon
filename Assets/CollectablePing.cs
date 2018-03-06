using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectablePing : MonoBehaviour {

    public GameObject collectable;
    AudioSource secret;
    bool hasEntered;
	// Use this for initialization
	void Start () {
        secret = GetComponent<AudioSource>();
        hasEntered = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider other)
    {
        Debug.Log(hasEntered);

        if(hasEntered == false)
        {
            if (collectable.activeSelf == true)
            {
                secret.Play();
                hasEntered = true;
            }
        }

        else if(hasEntered == true)
        {
            hasEntered = false;
        }
        
    }
}
