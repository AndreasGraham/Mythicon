using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Controller : MonoBehaviour
{
    public GameObject inGameMenu;
    bool ingame;
    //==============================================

    [SerializeField]
    private GameObject flowerQuestPanel;

    [SerializeField]
    private GameObject itemCounterPanel;

    [SerializeField]
    private Text questText;

    [SerializeField]
    private Text counterText;

    ItemCounter flower;

    //==============================================
    // Use this for initialization
    void Awake()
    {
        inGameMenu.SetActive(false);
        ingame = true;

        flowerQuestPanel.SetActive(false);
        itemCounterPanel.SetActive(false);

        flower = gameObject.GetComponent<ItemCounter>();
    }

    //==============================================
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            switch (ingame)
            {
                case true:
                    inGameMenu.SetActive(true);
                    Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
                    Time.timeScale = 0;
                    break;
                case false:
                    inGameMenu.SetActive(false);
                    Time.timeScale = 1;
                    break;
            }
            ingame = !ingame;
        }

    //==============================================

        if (Input.GetKey(KeyCode.Space))
        {
            flowerQuestPanel.SetActive(true);
            itemCounterPanel.SetActive(true);
        }

        if (flowerQuestPanel.activeInHierarchy == true)
        {
            questText.text = "Pick Flowers";
            counterText.text = "Flowers: " + flower.GetItemCount() + "/" + flower.GetCollectLimit(); 
        }

        if(flower.GetItemCount() >= flower.GetCollectLimit())
        {
            questText.text = "Go To Village";
            counterText.text = "Flowers: Completed " + flower.GetItemCount() + "/" + flower.GetCollectLimit();
        }
        
    }

    //==============================================
    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    //==============================================

    public void QuitGame()
    {
        Application.Quit();
    }
}
