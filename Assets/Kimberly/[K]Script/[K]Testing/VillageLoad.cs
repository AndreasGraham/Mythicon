using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VillageLoad : MonoBehaviour
{
    ItemCounter itemCounter;

    private void Awake()
    {
        itemCounter = GameObject.FindGameObjectWithTag("CountingManager").GetComponent<ItemCounter>();
    }


   
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Entered");
        if (other.gameObject.tag == "Player" && itemCounter.GetItemCount() >= itemCounter.GetCollectLimit())
        {
            SceneManager.LoadScene(2);
        }
    }
}
