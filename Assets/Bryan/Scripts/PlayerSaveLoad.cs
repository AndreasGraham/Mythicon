using System.Collections;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using UnityEngine;

public class PlayerSaveLoad : MonoBehaviour 
{
    [SerializeField, XmlAttribute("player position")]
    public Vector3 playerPos;
	
	// Update is called once per frame
	void Update () 
    {
        playerPos = transform.position;
	}
}
