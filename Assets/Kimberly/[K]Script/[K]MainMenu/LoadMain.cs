using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadMain
{
    MainMenu mainMenu = new MainMenu();

    public void getMainMenu()
    {
        mainMenu = GameObject.FindGameObjectWithTag("MainMenuCanvas").GetComponent<MainMenu>();
    }

    public MainMenu loadMainMenu()
    {
        return mainMenu;
    }
}
