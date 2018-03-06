using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Controller : MonoBehaviour
{
    [SerializeField]
    private GameObject inGameMenu;
    [SerializeField]
    private GameObject pickFlowerPanel;
    [SerializeField]
    private GameObject flowerNumberPanel;
    //==================================================

    [SerializeField]
    private Text pickText;
    [SerializeField]
    private Text counterText;
    //==================================================

    ItemCounter flowers;
    // Use this for initialization
    void Awake()
    {
        inGameMenu.SetActive(false);

        flowers = gameObject.GetComponent<ItemCounter>();
    }
    //==================================================

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (inGameMenu.activeSelf)
            {
                inGameMenu.SetActive(false);
                Time.timeScale = 1;
            }
            else
            {
                inGameMenu.SetActive(true);
                Time.timeScale = 0;
            }
        }

    //==================================================

        if(flowers.GetItem() >= flowers.GetCollectedLimit())
        {
            pickText.text = "Go to the Village";
            counterText.text = "Flowers: Completed";
        }
        else
        {
            pickText.text = "Pick Flowers";
            counterText.text = "Flowers: " + flowers.GetItem() + "/" + flowers.GetCollectedLimit();
        }
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
    //==================================================

    public void ReturnToGame()
    {
        inGameMenu.SetActive(false);
        Time.timeScale = 1;
    }
    //==================================================

    public void QuitGame()
    {
        Application.Quit();
    }
}
