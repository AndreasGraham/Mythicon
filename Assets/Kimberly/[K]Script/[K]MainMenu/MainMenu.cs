using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class MainMenu : MonoBehaviour
{
    public static bool isLoading = false;

    public void newGame(int index)
    {
        SceneManager.LoadScene(index);
        Time.timeScale = 1;
    }
    public void Quit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
    }
    public void Continue()
    {
        
        var savePath = Application.dataPath + "Save1";
        if(File.Exists(savePath))
        {
            isLoading = true;
            //int sceneIndex = SaveLoadWrapper.Load("Save1").sceneIndex;
            //SceneManager.LoadScene(sceneIndex)

        }
    }

    public bool getIsLoading()
    {
        return isLoading;
    }

}
