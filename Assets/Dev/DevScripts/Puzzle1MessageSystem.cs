using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Puzzle1MessageSystem : MonoBehaviour 
{
    ItemCounter itemCounter;
    QuestManager questManager;
    puzzle2Manager puz2Man;
    Puzzle3Manager puz3Man;
    [SerializeField] Text message;
    [SerializeField] Text counter;
    [SerializeField] GameObject puzzle1Sword;

    [SerializeField] bool graveYardTrigger;

	// Use this for initialization
	void Awake () 
    {
        itemCounter = GameObject.FindGameObjectWithTag("CountingManager").GetComponent<ItemCounter>();
        questManager = GameObject.FindGameObjectWithTag("PuzzleManager").GetComponent<QuestManager>();
        puz2Man = GameObject.FindGameObjectWithTag("PuzzleManager").GetComponent<puzzle2Manager>();
        puz3Man = GameObject.FindGameObjectWithTag("PuzzleManager").GetComponent<Puzzle3Manager>();
        message.text = "Find All Of The Clan Objects!";

        graveYardTrigger = false;
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        counter.text = itemCounter.GetItemCount().ToString() + "/" + itemCounter.GetCollectLimit().ToString();

        if (puzzle1Sword.activeSelf && !questManager.IsQuestComplete("Quest1"))
        {
            message.text = "GET THE SWORD!\n PLACE IT ON THE CLAN STONE NEAR THE CENTER TREE!";
            counter.enabled = false;
        }

        if (questManager.IsQuestComplete("Quest1") && !graveYardTrigger)
            message.text = "GO TO THE GRAVE YARD!";
        else if (!questManager.IsQuestComplete("Quest2") && graveYardTrigger && !puz2Man.GetBlue())
            message.text = "GET THE COLORED STONE AND PLACE\nTHEM IN FRONT OF THEIR TOMB!\n" +
            "BE CAREFUL THOUGH, ORDER MATTERS!";
        else if (!questManager.IsQuestComplete("Quest2") && puz2Man.GetBlue())
            message.text = "GET THE STATUE!\n PLACE IT ON THE CLAN STONE NEAR THE CENTER TREE!";
        else if (questManager.IsQuestComplete("Quest2") && !puz3Man.GetKey())
            message.text = "PRESS THE BUTTONS IN THE MAZE!\n CAREFUL! ORDER MATTERS!";
        else if (!questManager.IsQuestComplete("Quest3") && puz3Man.GetKey())
            message.text = "GET THE IDOL!\n PLACE IT ON THE CLAN STONE NEAR THE CENTER TREE!";
        else if (questManager.IsQuestComplete("Quest3") && puz3Man.GetKey())
        {
            message.text = "GREAT JOB!\n YOU SATISFIED THE GODS, AND BROUGHT BACK ALL OF YOUR PEOPLE!";

            Vector2 messagePos = message.transform.position;
            messagePos.y = Screen.height / 4;
            message.transform.position = messagePos;
        }
    }

    public void SetTrigger(bool newBool)
    {
        graveYardTrigger = newBool;
    }
}
