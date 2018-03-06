using System.Collections;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using UnityEngine;

public class CameraSaveLoad : MonoBehaviour 
{
    [XmlAttribute("Camera Position")]
    Vector3 cameraPos;

    [XmlAttribute("Camera Rotation")]
    Quaternion cameraRot;
	
	// Update is called once per frame
	void Update () 
    {
        cameraPos = transform.position;
        cameraRot = transform.rotation;
	}
}
