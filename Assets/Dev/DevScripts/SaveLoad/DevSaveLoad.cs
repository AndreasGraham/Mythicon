using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using UnityEngine;


[XmlRoot("SaveLoadManager")]
public class DevSaveLoad
{
    // Needed for SaveLoadWrapper
    [XmlIgnore]
    public PlayerSaveLoad playerPosScript;

    // Save The Player Position and Rotation
    [XmlElement("Player Position")]
    public Vector3 playerPos;
    [XmlElement("Player Rotation")]
    public Quaternion playerRot;

    // Save The Main Camera Position and Rotation
    [XmlElement("Camera Position")]
    public Vector3 cameraPos;
    [XmlElement("Camera Rotation")]
    public Quaternion cameraRot;

    // Needed for SaveLoadWrapper
    [XmlIgnore]
    public GameObject[] interactableObjs;
    [XmlIgnore]
    public InteractableObjects[] interactableObjsPosScript;

    // Save all of the bools for the interactables that can be held
    [XmlArray("Interactable Objects Held"), XmlArrayItem("Interactable")]
    public bool[] isInteractableHeld;
    // Save all of the positions of the interactable objects
    [XmlArray("Interactable Objects Position"), XmlArrayItem("Interactable")]
    public Vector3[] interActableObjsPos;
    // Save all of the rotations of the interactable objects
    [XmlArray("Interactable Objects Rotation"), XmlArrayItem("Interactable")]
    public Quaternion[] interactableObjsRot;

    // Needed for the SaveLoadWrapper
    [XmlIgnore]
    public GameObject[] enviroObjs;

    // Save all of the environment objects positions
    [XmlArray("Environment Objects Position"), XmlArrayItem("Dropable_Area")]
    public Vector3[] enviroObjsPos;
    // Save all of the environment objects rotations
    [XmlArray("Environment Objects Rotation"), XmlArrayItem("Droppable_Area")]
    public Quaternion[] enviroObjsRot;

    // Save the current scene index
    [XmlElement("Current Scene")]
    public int sceneIndex;

    // Tells the scene whether or not to load
    [XmlElement("Should The Scene Load")]
    public bool shouldLoad;

    // Save Method
    /** Note: The parameter is given in the SaveLoadWrapper **/
    public void Save(string playerSaveName)
    {
        string path = Application.dataPath + playerSaveName;
        var serializer = new XmlSerializer(typeof(DevSaveLoad));

        using(var stream = new FileStream(path, FileMode.Create))
        {
            serializer.Serialize(stream, this);
        }
    }

    // Load Method
    /** Note: The parameter is given in the SaveLoadWrapper **/
    public static DevSaveLoad Load(string playerSaveName)
    {
        string path = Application.dataPath + playerSaveName;

        var serializer = new XmlSerializer(typeof(DevSaveLoad));

        using (var stream = new FileStream(path, FileMode.Open))
        {
            return serializer.Deserialize(stream) as DevSaveLoad;
        }
    }
}
