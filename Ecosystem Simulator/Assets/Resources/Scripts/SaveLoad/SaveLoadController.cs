using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class SaveLoadController
{
    public static List<SavedEcosystem> savedEcosystems = new List<SavedEcosystem>();
    public static void Save()
    {

        // Get current Ecosystem to save
        savedEcosystems.Add(SavedEcosystem.current);
        
        // BinaryFormatter handles Serialization/Deserialization
        BinaryFormatter bf = new BinaryFormatter();
        
        // Get a file stream to save to. Application.persistenDataPath is a 
        // useful Unity reference that adapts to how you build game
        FileStream file = File.Create(Application.persistentDataPath + "/savedEcosystems.ses");
        bf.Serialize(file, SaveLoadController.savedEcosystems);
        file.Close();
    }

    public static void Load()
    {

    }
}
