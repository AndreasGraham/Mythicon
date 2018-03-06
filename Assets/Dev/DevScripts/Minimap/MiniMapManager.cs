using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMapManager : MonoBehaviour
{
    [SerializeField]
    RenderTexture minimapTexture;
    [SerializeField]
    Material minimapMaterial;

    float offset;

    void Awake()
    {
        offset = 10;
    }

    void OnGUI()
    {
        if(Event.current.type == EventType.Repaint)
            Graphics.DrawTexture(new Rect(Screen.width - 256 - offset, offset, 256, 256), minimapTexture, minimapMaterial);
    }
	
}
