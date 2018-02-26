using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Game 
{
    public static Game current;
    public PlayerSaveLoad player;
    public InteractableObjects[] interactables;
    public EnviroSaveLoad[] enviroObjs;

    public Game()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        interactables = GameObject.FindGameObjectsWithTag("Interactable");
        enviroObjs = GameObject.FindGameObjectsWithTag("Dropable_Area");
    }
	
}
