using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Droppable_Area_Animation : MonoBehaviour 
{
    Animator anim;

	// Use this for initialization
	void Start () 
    {
        anim = GetComponent<Animator>();
	}

    void OnCollisionEnter(Collision other)
    {
        if (other.collider.tag == "Interactable")
            anim.SetTrigger("moveDown");
    }
}
