using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraveyardTextChanger : MonoBehaviour
{
    QuestManager questManager;
    Puzzle1MessageSystem puzzleMessages;

    private void Awake()
    {
        questManager = GameObject.FindGameObjectWithTag("PuzzleManager").GetComponent<QuestManager>();
        puzzleMessages = GameObject.FindGameObjectWithTag("Messages").GetComponent<Puzzle1MessageSystem>();
    }

    private void OnTriggerExit(Collider other)
    {

        if(other.gameObject.tag == "Player")
        {
            if (questManager.IsQuestComplete("Quest1"))
            {
                puzzleMessages.SetTrigger(true);
                gameObject.GetComponent<Collider>().enabled = false;
            }
        }
    }
}
