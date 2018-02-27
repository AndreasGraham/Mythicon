using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour 
{
    Animator anim;
	// Use this for initialization
	void Start () 
    {
        anim = GetComponent<Animator>();	
	}
	
    public void SetWalkSpeed(float newSpeed)
    {
        anim.SetFloat("speed", newSpeed);
    }
}
