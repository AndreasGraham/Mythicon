using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorInfo : MonoBehaviour
{
    Ray ray;
    RaycastHit hit;

    public Texture2D walkable;
    public Texture2D interactive;
    public Texture2D NonInteractive;
    public Texture2D dropable;


    // Update is called once per frame
    void FixedUpdate()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if(Physics.Raycast(ray, out hit, float.PositiveInfinity))
        {
            switch(hit.collider.gameObject.layer)
            {
                case 8:
                    Cursor.SetCursor(walkable, Vector2.zero, CursorMode.Auto);
                    break;
                case 12:
                case 9:
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
