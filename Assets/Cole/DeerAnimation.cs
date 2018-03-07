using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeerAnimation : MonoBehaviour
{
    public AnimationCurve Hop;
    public float Strength;


    // Use this for initialization
    void Start ()
    {
       
	}
	
	// Update is called once per frame
	void Update () 
    {
        float yOffset = Hop.Evaluate(Time.time);
        transform.position += (Vector3.up * yOffset * Strength);
       //transform.translate(Vector3.up Time.deltaTime);
        
	}
}
