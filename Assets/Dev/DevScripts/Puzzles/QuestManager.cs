/**Written By: Bryan **/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class QuestManager : MonoBehaviour
{
    FirstPuzzle puz1Manager;
    puzzle2Manager puz2Manager;
    Puzzle3Manager puz3Manager;
    CameraManager camManager;
    GameObject player;

    [Header("Quest Complete Flags")]
    [SerializeField] bool isQuest1Complete;
    [SerializeField] bool isQuest2Complete;
    [SerializeField] bool isQuest3Complete;

    [Header("Puzzle/Game Complete Objects")]
    [SerializeField] GameObject puz1CompleteFire;
    [SerializeField] GameObject puz2CompleteFire;
    [SerializeField] GameObject puz3CompleteFire;
    [SerializeField] GameObject treeFire;
    [SerializeField] Camera endGameCamera;

    [Header("Clan Objects")]
    [SerializeField] GameObject clanOne;
    [SerializeField] GameObject clanTwo;
    [SerializeField] GameObject clanThree;

	// Use this for initialization
	void Awake ()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        puz1Manager = GameObject.FindGameObjectWithTag("PuzzleManager").GetComponent<FirstPuzzle>();
        puz2Manager = GameObject.FindGameObjectWithTag("PuzzleManager").GetComponent<puzzle2Manager>();
        puz3Manager = GameObject.FindGameObjectWithTag("PuzzleManager").GetComponent<Puzzle3Manager>();
        camManager = GameObject.FindGameObjectWithTag("CameraManager").GetComponent<CameraManager>();

        puz1CompleteFire.SetActive(false);
        puz2CompleteFire.SetActive(false);
        puz3CompleteFire.SetActive(false);
        treeFire.SetActive(false);

        isQuest1Complete = false;
        isQuest2Complete = false;
        isQuest3Complete = false;

        clanOne.SetActive(false);
        clanTwo.SetActive(false);
        clanThree.SetActive(false);
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        if (puz1Manager.GetAnimationPlayed())
            puz1CompleteFire.SetActive(true);

        if (puz2Manager.GetAnimComplete())
            puz2CompleteFire.SetActive(true);

        if (puz3Manager.GetAnimComplete())
        {
            puz3CompleteFire.SetActive(true);            
        }

        if(isQuest1Complete && !clanOne.activeSelf)
            clanOne.SetActive(true);

        if (isQuest2Complete && !clanTwo.activeSelf)
            clanTwo.SetActive(true);

        if (isQuest3Complete && !clanThree.activeSelf)
            clanThree.SetActive(true);

        if (AllQuestsComplete())
        {
            Debug.Log("All Citizens Should Be Instatiated!\n Quests Complete!");
            treeFire.SetActive(true);
            if(camManager.GetCurrentCamera() != endGameCamera)
                camManager.ChangeCameras(endGameCamera);
            player.GetComponent<NavMeshAgent>().SetDestination(player.transform.position);
        }
    }

    public void SetQuest1Complete(bool isQuestComplete)
    {
        if (!isQuest1Complete)
            isQuest1Complete = isQuestComplete;
    }

    public bool IsQuestComplete(string requestedQuest, bool isCheck = true)
    {
        bool isQuestComplete = false;
        if (isCheck)
        {
            switch (requestedQuest)
            {
                case "Quest1":
                    isQuestComplete = isQuest1Complete;
                    break;
                case "Quest2":
                    isQuestComplete = isQuest2Complete;
                    break;
                case "Quest3":
                    isQuestComplete = isQuest3Complete;
                    break;
                default:
                    break;
            }
        }
        return isQuestComplete;
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
