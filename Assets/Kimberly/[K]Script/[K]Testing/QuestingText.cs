using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestingText : MonoBehaviour
{
    public List<string> quest = new List<string>(); //creats a list of the quests

    QuestManager questManager;

    //public string questing; //current quest
    //public string nextQuest; //the quest up next
    public string Complete; //changes quest progress to complete


    public Text questText; //contains what the player must do
    public Text progressText; //how far the player is

    ItemCounter itemCounter; //contains item, collectLimit

    public int newCollectLimit; //Sets a new Limit

    public float timer;
    public float timerlimit; //when to stop timer

    public bool newScene;

    //QuestManager questManager;

    void Start()
    {
        itemCounter = gameObject.GetComponent<ItemCounter>();
        questManager = GameObject.FindGameObjectWithTag("PuzzleManager").GetComponent<QuestManager>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
       if (!questManager.IsQuestComplete("Quest1"))
        {
            questText.text = quest[0];
            progressText.text = itemCounter.GetItemCount().ToString() + "/" + itemCounter.GetCollectLimit().ToString();
        }
       else if (!questManager.IsQuestComplete("Quest2"))
        {
            questText.text = quest[1];
            progressText.enabled = false;
        }
       else
        {
            questText.text = quest[2];
        }



        //    if (itemCounter.item >= itemCounter.collectLimit && ) //checks to see if the item has hit the collectLimit
        //    {
        //        timer += Time.deltaTime;
        //        questText.text = quest[0]; // if so the player is given a new quest
        //        progressText.text = Complete; //say complete

        //        if (timer >= timerlimit)
        //        {
        //            itemCounter.item = 0;
        //            questing = nextQuest;
        //        }
        //    }
        //    else if (questing == nextQuest)
        //    {
        //        progressText.enabled = false;
        //    }
        //    else
        //    {
        //        timer = 0;
        //        questText.text = questing; //for now just keep current quest
        //        progressText.text = itemCounter.item + "/" + itemCounter.collectLimit; //shows the players progress
        //    }
        //}
    }
    public void setText(string newQuest)
    {
        quest[1] = newQuest;
    }
}
