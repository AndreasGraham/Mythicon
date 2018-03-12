using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraveyardTextChanger : MonoBehaviour
{
    QuestingText questingText;
    QuestManager questManager;

    private void Awake()
    {
        questingText = GameObject.FindGameObjectWithTag("CountingManager").GetComponent<QuestingText>();
        questManager = GameObject.FindGameObjectWithTag("PuzzleManager").GetComponent<QuestManager>();
    }

    private void OnTriggerExit(Collider other)
    {

        if(other.gameObject.tag == "Player")
        {
            if (questManager.IsQuestComplete("Quest1"))
            {
                questingText.setText("Place the stones in the correct order");
                gameObject.GetComponent<Collider>().enabled = false;
            }
        }
    }
}
