using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialUI : MonoBehaviour
{
   [SerializeField]
    private Text right;

    public float timer;

   [SerializeField]
    private Text left;

    Player player;
    // Use this for initialization
    void Start()
    {
        right.enabled = false;
        left.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
       
    if (Input.GetKey(KeyCode.F))
        {
            right.enabled = true;
            timer += Time.deltaTime;
        }
    if(Input.GetKey(KeyCode.A))
        {
            left.enabled = true;
            timer += Time.deltaTime;
        }
    if (timer == 5 && right.enabled == true)
        {
            right.enabled = false;
            timer = 0;
        }
    if (timer == 5 && left.enabled == true)
        {
            left.enabled = false;
            timer = 0;
        }
    }
}
