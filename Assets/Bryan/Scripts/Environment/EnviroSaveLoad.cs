using System.Collections;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using UnityEngine;

public class EnviroSaveLoad : MonoBehaviour 
{
    [XmlAttribute("Drop Area Position")]
    Vector3 objectPos;

    [XmlAttribute("Drop Area Rotation")]
    Quaternion objectRot;

    void Update()
    {
        objectPos = transform.position;
        objectRot = transform.rotation;
    }
}
