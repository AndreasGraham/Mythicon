using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastleDoorTrigger : MonoBehaviour 
{
    [SerializeField]
    GameObject[] floors;

    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            foreach (GameObject floor in floors)
            {
                floor.GetComponent<Renderer>().enabled = false;
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            foreach (GameObject floor in floors)
            {
                floor.GetComponent<Renderer>().enabled = true;
            }
        }
    }
}
