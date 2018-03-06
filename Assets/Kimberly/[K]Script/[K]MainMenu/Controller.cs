using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Controller : MonoBehaviour
{
    public GameObject inGameMenu;
    public GameObject pickFlowerPanel;
    public GameObject flowerNumberPanel;
    //==================================================

    public Text pickText;
    public Text counterText;
    //==================================================

    ItemCounter flowers;
    // Use this for initialization
    void Awake()
    {
        inGameMenu.SetActive(false);
        pickFlowerPanel.SetActive(false);
        flowerNumberPanel.SetActive(false);

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
        if (Input.GetKey(KeyCode.Space))
        {
            pickFlowerPanel.SetActive(true);
            flowerNumberPanel.SetActive(true);
        }

        if(pickFlowerPanel.activeInHierarchy == true)
        {
            pickText.text = "Pick Flowers";
            counterText.text = "Flowers: " + flowers.item;
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
