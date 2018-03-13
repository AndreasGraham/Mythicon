using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlowerQuest : MonoBehaviour
{
    [SerializeField]
    private Text counterText;

    [SerializeField]
    private GameObject flowerQuestPanel;

    [SerializeField]
    private GameObject itemCounterPanel;

    [SerializeField]
    private Text questText;


    ItemCounter flower;
    // Use this for initialization
    void Start()
    {
        flower = GameObject.FindGameObjectWithTag("CountingManager").GetComponent<ItemCounter>();
    }

    // Update is called once per frame
    void Update()
    {
        if (flower.GetItemCount() >= flower.GetCollectLimit())
        {
            questText.text = "Go to the Village";
            counterText.text = "Flowers: Completed";
        }
        else
        {
            questText.text = "Pick Flowers";
            counterText.text = "Flowers: " + flower.GetItemCount() + "/" + flower.GetCollectLimit();
        }
    }
}
