using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerEvent : MonoBehaviour
{
    void OnTriggerEnter()
    {
        Debug.Log("Enter");
    }

    void OnTriggerStay()
    {
        Debug.Log("Stay");
    }

    void OnTriggerExit()
    {
        Debug.Log("Exit");
    }
}
