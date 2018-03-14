using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VillageEnter : MonoBehaviour
{
    ItemCounter Flowers;

    void Awake()
    {
        Flowers = GameObject.FindGameObjectWithTag("CountingManager").GetComponent<ItemCounter>();
    }
	
    void OnTriggerEnter (Collider other)
    {
        if(other.tag == "Player" && Flowers.GetItemCount() >= Flowers.GetCollectLimit())
        {
            SceneManager.LoadScene("DevVillage");
        }
    }
}
