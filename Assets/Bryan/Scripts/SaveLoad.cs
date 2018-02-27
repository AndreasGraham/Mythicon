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

    [SerializeField, XmlElement("Player")]
    public Vector3 playerPos;

    [XmlIgnore]
    public GameObject[] interactableObjs;
    [XmlIgnore]
    public InteractableObjects[] interactableObjsPosScript;

    [SerializeField, XmlArray("Interactable Objects"), XmlArrayItem("Interactable")]
    public Vector3[] interActableObjsPos;

    [XmlIgnore]
    public GameObject[] enviroObjs;

    [SerializeField, XmlArray("Environment Objects"), XmlArrayItem("Dropable_Area")]
    public Vector3[] enviroObjsPos;

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
