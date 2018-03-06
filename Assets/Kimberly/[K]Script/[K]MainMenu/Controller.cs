using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Controller : MonoBehaviour
{
    public GameObject inGameMenu;
    public GameObject TextPanel;
    public GameObject itemPanel;
    ItemCount item;
    bool ingame;
    public Text itemCount;
    public Text flowerPick;

   public float timer;
    // Use this for initialization
    void Awake()
    {
    
        inGameMenu.SetActive(false);
        ingame = true;

        itemPanel.SetActive(false);
        TextPanel.SetActive(false);
        item = gameObject.GetComponent<ItemCount>();

        timer = 0;
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

        if (Input.GetKey(KeyCode.Space))
        {
            TextPanel.SetActive(true);
            itemPanel.SetActive(true);
        }

        if (TextPanel.active == true)
        {

            flowerPick.text = "Pick Flowers";
            itemCount.text = "Flowers: " + item.ItemNumber;
            timer += Time.deltaTime;
            if (timer >= 5)
            {
                TextPanel.SetActive(false);
            }
        }

        if (item.ItemNumber > 12)
        {
            item.ItemNumber = 12;
        }

        if (item.ItemNumber == 12)
        {
            TextPanel.SetActive(true);
            if (TextPanel.active == true)
            {

                flowerPick.text = "All flowers have been collected";
                itemCount.text = "Flowers: Completed";
                timer += Time.deltaTime;
            }
            if (timer >= 5)
            {
                TextPanel.SetActive(false);
                itemPanel.SetActive(false);
                item.ItemNumber = 0;
            }
        }
        else
        {
            timer = 0;
            TextPanel.SetActive(false);
        }
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void ReturnToGame()
    {
        ingame = false;
        inGameMenu.SetActive(false);
        Time.timeScale = 1;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
    private void OnTriggerEnter(Collider other)
    {
        //if(other.gameObject.tag == )
        //{

        //}
    }
}
