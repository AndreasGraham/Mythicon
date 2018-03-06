using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCounter : MonoBehaviour
{
  
    private int item = 0;

    [SerializeField]
    private int collectLimit;

    public void SetItem(int newItem)
    {
        item += newItem;
        if (item >= collectLimit)
        {
            item = collectLimit;
        }
    }

    public int GetItem()
    {
        return item;
    }

    public int GetCollectedLimit()
    {
        return collectLimit;
    }
}
