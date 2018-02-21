using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Controller : MonoBehaviour
{
    public GameObject inGameMenu;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("escape"))
        {
            inGameMenu.SetActive(true);
            Time.timeScale = 0;
        }
        if(inGameMenu.activeSelf == false)
        {
            Time.timeScale = 1;
        }
    }
}
