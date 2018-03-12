using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    PuzzleManager puz1Manager;
    puzzle2Manager puz2Manager;
    Puzzle3Manager puz3Manager;

    bool isQuest1Complete;
    bool isQuest2Complete;
    bool isQuest3Complete;

    [SerializeField] GameObject puz1CompleteFire;
    [SerializeField] GameObject puz2CompleteFire;
    [SerializeField] GameObject puz3CompleteFire;

	// Use this for initialization
	void Awake ()
    {
        puz1Manager = GameObject.FindGameObjectWithTag("PuzzleManager").GetComponent<PuzzleManager>();
        puz2Manager = GameObject.FindGameObjectWithTag("PuzzleManager").GetComponent<puzzle2Manager>();
        puz3Manager = GameObject.FindGameObjectWithTag("PuzzleManager").GetComponent<Puzzle3Manager>();

        puz1CompleteFire.SetActive(false);
        puz2CompleteFire.SetActive(false);
        puz3CompleteFire.SetActive(false);
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        if (puz1Manager.GetAnimComplete())
            puz1CompleteFire.SetActive(true);

        if (puz2Manager.GetAnimComplete())
            puz2CompleteFire.SetActive(true);

        if (puz3Manager.GetAnimComplete())
            puz3CompleteFire.SetActive(true);

        if (AllQuestsComplete())
            Debug.Log("All Citizens Should Be Instatiated!\n Quests Complete!");
	}

    public void SetQuest1Complete(bool isQuestComplete)
    {
        if (!isQuest1Complete)
            isQuest1Complete = isQuestComplete;
    }

    public void SetQuest2Complete(bool isComplete)
    {
        if (!isQuest2Complete)
            isQuest2Complete = isComplete;
    }

    public void SetQuest3Complete(bool isComplete)
    {
        if(!isQuest3Complete)
            isQuest3Complete = isComplete;
    }

    bool AllQuestsComplete()
    {
        return isQuest1Complete && isQuest2Complete && isQuest3Complete ? true : false;
    }
}
