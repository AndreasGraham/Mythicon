using System.Collections;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using UnityEngine;

public class InteractableObjects : MonoBehaviour 
{
    [XmlAttribute("Interactable")]
    public Vector3 objectPos;

    void Update()
    {
        objectPos = transform.position;
    }
}
