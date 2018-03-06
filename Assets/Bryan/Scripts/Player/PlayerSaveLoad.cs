using System.Collections;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerSaveLoad : MonoBehaviour 
{
    [SerializeField, XmlAttribute("player position")]
    public Vector3 playerPos;

    [XmlAttribute("Player Rotation")]
    public Quaternion playerRot;

    [XmlAttribute("Player Layer")]
    public int layer;

    [XmlAttribute("Active Scene")]
    public int sceneIndex;

    void Start()
    {
        layer = gameObject.layer;
        sceneIndex = SceneManager.GetActiveScene().buildIndex;
    }
	
	// Update is called once per frame
	void Update () 
    {
        playerPos = transform.position;
        playerRot = transform.rotation;

	}
}
