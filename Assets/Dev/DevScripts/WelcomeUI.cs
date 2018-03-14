/** Written By: Bryan **/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WelcomeUI : MonoBehaviour 
{
    [SerializeField] Text storyText;
    [SerializeField] GameObject puzzle1Messages;

	// Use this for initialization
	void Awake () 
    {
        storyText.text = "WELCOME TO THE VILLAGE!\n THE GODS HAVE TAKEN YOUR PEOPLE!\n TO GET THEM BACK YOU MUST SOLVE THE PUZZLES!";
        puzzle1Messages.SetActive(false);

        Vector2 messagePos = storyText.transform.position;
        messagePos.y = Screen.height / 4;
        storyText.transform.position = messagePos;
	}
	
    void Start()
    {
        StartCoroutine("DisableWelcome");
    }

    IEnumerator DisableWelcome()
    {
        float delay = 0f;

        while (delay < 6f)
        {
            delay++;

            yield return new WaitForSeconds(1f);
        }
        puzzle1Messages.SetActive(true);
        gameObject.SetActive(false);
    }
	
}
