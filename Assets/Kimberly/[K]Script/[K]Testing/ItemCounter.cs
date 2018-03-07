using UnityEngine;
using System.Collections;

public class ItemCounter : MonoBehaviour {


    private int item;

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

    public int GetItemCount()
    {
        return item;
    }

    public int GetCollectLimit()
    {
        return collectLimit;
    }
}

