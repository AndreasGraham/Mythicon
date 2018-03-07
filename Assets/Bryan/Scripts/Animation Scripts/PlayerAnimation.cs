using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour 
{
    Animator anim;

    [SerializeField]
    private Animation[] animations;
    private Animation currentAnimation;

	// Use this for initialization
	void Start () 
    {
        anim = GetComponent<Animator>();	
	}

    void Update()
    {
        currentAnimation = GetCurrentAnimation();
    }
	
    public void SetWalkSpeed(float newSpeed)
    {
        anim.SetFloat("speed", newSpeed);
    }

    public float GetWalkSpeed()
    {
        return anim.GetFloat("speed");
    }

    public void SetIsCarrying(bool newBool)
    {
        anim.SetBool("isCarrying", newBool);
    }

    public bool GetIsCarrying()
    {
        return anim.GetBool("isCarrying");
    }

    public void SetIsPickingUp(bool newBool)
    {
        anim.SetBool("isPickingUp", newBool);
    }

    public bool GetIsPickingUp()
    {
        return anim.GetBool("isPickingUp");
    }

    public Animation GetCurrentAnimation()
    {
        Animation a1 = new Animation();
        foreach (Animation a in animations)
        {
            if (a.isPlaying)
                return a;
        }

        return a1;
    }

    public bool IsAnimPlaying(Animation currentAnim)
    {
        bool isPlaying = currentAnim.isPlaying;
        return isPlaying;
    }
}
