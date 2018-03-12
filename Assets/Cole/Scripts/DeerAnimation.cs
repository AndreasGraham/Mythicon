using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeerAnimation : MonoBehaviour
{
    public AnimationCurve Hop;
    public float Strength;

    private float startingY;


    // Use this for initialization
    void Start ()
    {
        Hop.postWrapMode = WrapMode.Loop;
        startingY = transform.position.y;
	}
	
	// Update is called once per frame
	void Update () 
    {
        float yOffset = Hop.Evaluate(Time.time);
        transform.position += (Vector3.up * yOffset * Strength);

        Vector3 finalOffset = transform.position;
        finalOffset.y = (startingY + yOffset * Strength);
        transform.position = finalOffset;

       //transform.translate(Vector3.up Time.deltaTime);

    }
    IEnumerator JumpDelay()
    {
        int sec = 0;

        while (sec < 200)
        {
            sec++;

            yield return new WaitForSeconds(1);
        }

        // camManager.ChangeCameras(camManager.GetPreviousCamera());
    }
}
