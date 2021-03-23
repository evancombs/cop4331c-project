using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class SaveLoadController : MonoBehaviour
{
    public static List<SavedEcosystem> savedEcosystems = new List<SavedEcosystem>();

    // Info Source: https://gamedevelopment.tutsplus.com/tutorials/how-to-save-and-load-your-players-progress-in-unity--cms-20934
    public static void Save()
    {

        // Get current Ecosystem to save
        savedEcosystems.Add(getCurrentEcosystem());
        
        // BinaryFormatter handles Serialization/Deserialization
        BinaryFormatter bf = new BinaryFormatter();
        
        // Get a file stream to save to. Application.persistenDataPath is a 
        // useful Unity reference that adapts to how you build game
        FileStream file = File.Create(Application.persistentDataPath + "/savedEcosystems.es");
        bf.Serialize(file, SaveLoadController.savedEcosystems);
        file.Close();
    }

    public static void Load()
    {
        if (File.Exists(Application.persistentDataPath + "/savedEcosystems.es"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/savedEcosystems.es", FileMode.Open);
            SaveLoadController.savedEcosystems = (List<SavedEcosystem>)bf.Deserialize(file);
            file.Close();
        }
    }

    public static SavedEcosystem getCurrentEcosystem()
    {
        Debug.Log("Preparing to profile...");
        SavedEcosystem save = new SavedEcosystem();
        GameObject ecoRef = GameObject.FindGameObjectWithTag("ecosystem");
        // Gather arrays of references to all ecosystem components
        GameObject[] predators = GameObject.FindGameObjectsWithTag("predator");
        GameObject[] prey = GameObject.FindGameObjectsWithTag("prey");
        GameObject[] flora = GameObject.FindGameObjectsWithTag("flora");
        GameObject[] faunaNutrients = GameObject.FindGameObjectsWithTag("faunaNutrient");
        GameObject[] floraNutrients = GameObject.FindGameObjectsWithTag("floraNutrient");
        GameObject[] waterSources = GameObject.FindGameObjectsWithTag("waterSource");

        // Loop through each and add them to our save.

        // Nutrients
        for (int i = 0; i < faunaNutrients.Length; i++)
            save.addNutrient(faunaNutrients[i]);
        for (int i = 0; i < floraNutrients.Length; i++)
            save.addNutrient(floraNutrients[i]);

        // Water
        for (int i = 0; i < waterSources.Length; i++)
            save.addWaterSource(waterSources[i]);

        // Organisms
        for (int i = 0; i < prey.Length; i++)
            save.addOrganism(prey[i]);
        for (int i = 0; i < predators.Length; i++)
            save.addOrganism(prey[i]);
        for (int i = 0; i < flora.Length; i++)
            save.addOrganism(flora[i]);

        Debug.Log("Finished profile save! Returning to Save()");
        return save;
    }
}
