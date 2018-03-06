﻿using System.Collections;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InteractableObjects : MonoBehaviour 
{
    [XmlAttribute("Interactable Object Position")]
    public Vector3 objectPos;
    [XmlAttribute("Interactable Object Rotation")]
    public Quaternion objectRot;
    [XmlAttribute("Interactable Object Scale")]
    public Vector3 objectScale;
    [XmlAttribute("Interactable Object Layer")]
    public int layerIndex;

    [XmlAttribute("Interactable Object Parent")]
    public bool isBeingHeld = false;

    [XmlIgnore]
    private Transform player;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    void Update()
    {
        objectPos = transform.position;
        objectRot = transform.rotation;
        objectScale = transform.lossyScale;
        layerIndex = gameObject.layer;

        if (transform.parent == player)
            isBeingHeld = true;
        else
            isBeingHeld = false;
    }
}


