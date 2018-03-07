using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Controller : MonoBehaviour
{
    [SerializeField]
    private Text counterText;
    public GameObject inGameMenu;
    bool ingame;
    //==============================================

    [SerializeField]
    private GameObject flowerQuestPanel;

    [SerializeField]
    private GameObject itemCounterPanel;

    [SerializeField]
    private Text questText;


    ItemCounter flower;
    // Use this for initialization
    void Awake()
    {
        inGameMenu.SetActive(false);
        ingame = true;

       



        flower = gameObject.GetComponent<ItemCounter>();
    }

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

        if(flower.GetItemCount() >= flower.GetCollectLimit())
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

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void ReturnToGame()
    {
        inGameMenu.SetActive(false);
        Time.timeScale = 1;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
