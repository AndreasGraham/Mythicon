using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneLoader : MonoBehaviour
{
    [SerializeField]
    private LoadMain loadMenu = new LoadMain();
    [SerializeField]
    private SaveLoadWrapper loading;

    private MainMenu menu;
    private void Awake()
    {
        LoadingScene();
    }
    void LoadingScene()
    {
        menu = loadMenu.loadMainMenu();
        loading = Camera.main.GetComponent<SaveLoadWrapper>();
        if(menu.getIsLoading())
        {
            loading.Load("Save1");
        }
    }
}
