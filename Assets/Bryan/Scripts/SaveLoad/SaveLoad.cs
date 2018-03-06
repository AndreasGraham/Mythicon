using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using UnityEngine;


[XmlRoot("SaveLoadManager")]
public class SaveLoad
{
    [XmlIgnore]
    public PlayerSaveLoad playerPosScript;

    [XmlElement("Player Position")]
    public Vector3 playerPos;
    [XmlElement("Player Rotation")]
    public Quaternion playerRot;

    [XmlElement("Camera Position")]
    public Vector3 cameraPos;
    [XmlElement("Camera Rotation")]
    public Quaternion cameraRot;

    [XmlIgnore]
    public GameObject[] interactableObjs;
    [XmlIgnore]
    public InteractableObjects[] interactableObjsPosScript;

    [XmlArray("Interactable Objects Held"), XmlArrayItem("Interactable")]
    public bool[] isInteractableHeld;
    [XmlArray("Interactable Objects Position"), XmlArrayItem("Interactable")]
    public Vector3[] interActableObjsPos;
    [XmlArray("Interactable Objects Rotation"), XmlArrayItem("Interactable")]
    public Quaternion[] interactableObjsRot;

    [XmlIgnore]
    public GameObject[] enviroObjs;

    [XmlArray("Environment Objects Position"), XmlArrayItem("Dropable_Area")]
    public Vector3[] enviroObjsPos;
    [XmlArray("Environment Objects Rotation"), XmlArrayItem("Droppable_Area")]
    public Quaternion[] enviroObjsRot;

    [XmlElement("Current Scene")]
    public int sceneIndex;

    [XmlElement("Should The Scene Load")]
    public bool shouldLoad;

    public void Save(string playerSaveName)
    {
        string path = Application.dataPath + playerSaveName;
        var serializer = new XmlSerializer(typeof(SaveLoad));

        using(var stream = new FileStream(path, FileMode.Create))
        {
            serializer.Serialize(stream, this);
        }
    }

    public static SaveLoad Load(string playerSaveName)
    {
        string path = Application.dataPath + playerSaveName;

        var serializer = new XmlSerializer(typeof(SaveLoad));

        using (var stream = new FileStream(path, FileMode.Open))
        {
            return serializer.Deserialize(stream) as SaveLoad;
        }
    }
}
