using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuController : MonoBehaviour 
{
    [SerializeField] GameObject pauseMenu;

	// Use this for initialization
	void Awake() 
    {
        pauseMenu.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!pauseMenu.activeSelf)
            {
                pauseMenu.SetActive(true);
                Time.timeScale = 0f;
            }
            else
            {
                pauseMenu.SetActive(false);
                Time.timeScale = 1f;
            }
        }
	}

    public void MainMenu()
    {
        SceneManager.LoadScene("DevMainMenu");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
