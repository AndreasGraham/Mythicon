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

   
    // Use this for initialization
    void Awake()
    {
        inGameMenu.SetActive(false);
        ingame = true;
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
