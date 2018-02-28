using System.Collections;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using UnityEngine;

public class EnviroSaveLoad : MonoBehaviour 
{
    [SerializeField, XmlAttribute("Interactable")]
    Transform objectPos;

    void Update()
    {
        objectPos = transform;
    }
}
