using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class Ksave 
{
    public static List<kGame> saveCharacter = new List<kGame>();

    public static void save()
    {
        saveCharacter.Add(kGame.current);
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/Save.gd");
        bf.Serialize(file, Ksave.saveCharacter);
        Debug.Log("Saved");
        file.Close();
    }
}
