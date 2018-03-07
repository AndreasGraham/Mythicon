using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickLimit : MonoBehaviour
{
    public BoxCollider Holder;
    public int limit;
    ItemCounter flowers;

    // Use this for initialization
    void Start()
    {
        //Holder = gameObject.GetComponent<BoxCollider>();
        flowers = Camera.main.GetComponent<ItemCounter>();  
    }

    // Update is called once per frame
    void Update()
    {
      if (flowers.GetItemCount() >= limit)
        {
            Destroy(Holder);
        }
    }
}
