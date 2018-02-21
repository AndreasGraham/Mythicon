using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Start : MonoBehaviour
{
    public void start(int index)
    {
        SceneManager.LoadScene(index);
        Time.timeScale = 1;
    }

}
