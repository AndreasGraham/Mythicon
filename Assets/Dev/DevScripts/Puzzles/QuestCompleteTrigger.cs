using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestCompleteTrigger : MonoBehaviour
{
    QuestManager questManager;

    void Awake()
    {
        questManager = GameObject.FindGameObjectWithTag("PuzzleManager").GetComponent<QuestManager>();
    }

    private void OnCollisionEnter(Collider other)
    {
        if (other.gameObject.name == "sword4" && gameObject.name == "Clan1Stone")
            questManager.SetQuest1Complete(true);
        else if (other.gameObject.name == "Puzzle2CompletionObj" && gameObject.name == "Clan2Stone")
            questManager.SetQuest2Complete(true);
        else if (other.gameObject.name == "Puzzle3CompletionObj" && gameObject.name == "Clan3Stone")
            questManager.SetQuest3Complete(true);
    }
}
