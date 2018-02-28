using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Controller : MonoBehaviour
{
    public GameObject inGameMenu;
    // Use this for initialization
    void Awake()
    {
        inGameMenu.SetActive(false);
    }

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
