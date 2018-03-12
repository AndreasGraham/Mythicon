using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PillarInteraction : MonoBehaviour
{
    public static bool hasTriggeredPed1;
    public string objTag;
    public Pillars mypillar;
    public static bool PillarCheck;
        void OnTriggerEnter(Collider other)
        {
            PillarManager.pillar1 = true;
        if (other.tag == objTag)
        {
            PillarManager.updateFinalState(mypillar);
        }
        }
}


public enum Pillars
{
    pillar1,
    pillar2,
    pillar3

}

public class PillarManager
{
    public static bool pillar1;
    public static bool pillar2;
    public static bool pillar3;
    public static bool allPillarsAtive;

    public static void updateFinalState(Pillars whatPillar)
    {
        //This
        switch (whatPillar)
        {
            case Pillars.pillar1:
                pillar1 = true;
                break;
            case Pillars.pillar2:
                pillar2 = true;
                break;
            case Pillars.pillar3:
                pillar3 = true;
                break;
        }


        if(pillar1 == true && pillar2 == true && pillar3 == true)
        {
            allPillarsAtive = true;
        }

    }

}

