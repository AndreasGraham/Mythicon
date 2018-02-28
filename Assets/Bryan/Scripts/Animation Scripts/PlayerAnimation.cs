using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour 
{
    Animator anim;

    public Animation walking;
    public Animation carryingWalk;
    public Animation carryingIdle;
    public Animation lifting;
    public Animation idle;

	// Use this for initialization
	void Start () 
    {
        anim = GetComponent<Animator>();	
	}
	
    public void SetWalkSpeed(float newSpeed)
    {
        anim.SetFloat("speed", newSpeed);
    }

    public void SetIsCarrying(bool newBool)
    {
        anim.SetBool("isCarrying", newBool);
    }

    public void SetIsPickingUp(bool newBool)
    {
        anim.SetBool("isPickingUp", newBool);
    }
}
