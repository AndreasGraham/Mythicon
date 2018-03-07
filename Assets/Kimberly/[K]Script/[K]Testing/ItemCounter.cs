<<<<<<< HEAD
﻿using UnityEngine;
using System.Collections;

public class ItemCounter : MonoBehaviour {


=======
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCounter : MonoBehaviour {

   
>>>>>>> 5d4f98721e48ced15b9f184aee39b2eef024003d
    private int item;

    [SerializeField]
    private int collectLimit;

    public void SetItem(int newItem)
    {
        item += newItem;
<<<<<<< HEAD
        if (item >= collectLimit)
=======
        if(item >= collectLimit)
>>>>>>> 5d4f98721e48ced15b9f184aee39b2eef024003d
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
<<<<<<< HEAD

=======
>>>>>>> 5d4f98721e48ced15b9f184aee39b2eef024003d
