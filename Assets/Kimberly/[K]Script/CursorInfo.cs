using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorInfo : MonoBehaviour
{
    Ray ray;
    RaycastHit hit;

    CameraManager camManager;

    public Texture2D walkable;
    public Texture2D interactive;
    public Texture2D NonInteractive;
    public Texture2D dropable;


    // Update is called once per frame
    void FixedUpdate()
    {
        camManager = GameObject.FindGameObjectWithTag("CameraManager").GetComponent<CameraManager>();

        ray = camManager.GetCurrentCamera().ScreenPointToRay(Input.mousePosition);

        if(Physics.Raycast(ray, out hit, float.PositiveInfinity))
        {
            switch(hit.collider.gameObject.layer)
            {
                case 8:
                    Cursor.SetCursor(walkable, Vector2.zero, CursorMode.Auto);
                    break;
                case 12:
                case 9:
                case 14:
                    Cursor.SetCursor(interactive, Vector2.zero, CursorMode.Auto);
                    break;
                case 10:
                    Cursor.SetCursor(dropable, Vector2.zero, CursorMode.Auto);
                    break;
                default:
                    Cursor.SetCursor(NonInteractive, Vector2.zero, CursorMode.Auto);
                    break;
            }
        }
    }
}
