using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCounter : MonoBehaviour
{
    [SerializeField]
    public int item;

    public int collectLimit;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            item++;
        }
        if(item >= collectLimit)
        {
            item = collectLimit;
        }
    }
}
