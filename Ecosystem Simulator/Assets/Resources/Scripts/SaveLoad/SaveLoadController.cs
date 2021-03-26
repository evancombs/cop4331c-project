using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine.UI;

public class SaveLoadController : MonoBehaviour
{
    public static List<SavedEcosystem> savedEcosystems = new List<SavedEcosystem>();
    public Button saveButton, loadButton;
    public static GameObject ecosystem;

    private void Start()
    {
        saveButton.onClick.AddListener(Save);
        loadButton.onClick.AddListener(Load);
    }

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
        loadEntireEcosystem(savedEcosystems[0]);
    }

    // This function nukes the entire ecosystem and reinstantiates everything based
    // on the SavedEcosystem passed in
    public static void loadEntireEcosystem(SavedEcosystem saveToLoad)
    {
        // Clear the old, to make way for the new
        destroyEcosystem();
        
        // Now we loop through the lists in the SavedEcosystem to instantiate them into the simulation
        for (int i = 0; i < saveToLoad.prey.Count; i++)
            Instantiate(SavedPrey.loadPrey(saveToLoad.prey[i]));

        for (int i = 0; i < saveToLoad.predators.Count; i++)
            Instantiate(SavedPredator.loadPredator(saveToLoad.predators[i]));

        for (int i = 0; i < saveToLoad.flora.Count; i++)
            Instantiate(SavedFlora.loadFlora(saveToLoad.flora[i]));

        for (int i = 0; i < saveToLoad.nutrients.Count; i++)
            Instantiate(saveToLoad.nutrients[i]);
        for (int i = 0; i < saveToLoad.waterSources.Count; i++)
            Instantiate(saveToLoad.waterSources[i]);
    }

    // Destroys all children of this Ecosystem
    private static void destroyEcosystem()
    {
        foreach (Transform child in ecosystem.transform)
            Destroy(child);
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
        // Here we have "gathered" all of the organism GameObjects. We use
        // the save[organism]() functions for each respective organism to convert it to
        // a saveable (serializable) class and add it to our list of SavedOrganisms.
        for (int i = 0; i < prey.Length; i++)
            save.addPrey(SavedPrey.savePrey(prey[i]));
        for (int i = 0; i < predators.Length; i++)
            save.addPredator(SavedPredator.savePredator(prey[i]));
        for (int i = 0; i < flora.Length; i++)
            save.addFlora(SavedFlora.saveFlora(flora[i]));

        Debug.Log("Finished profile save! Returning to Save()");
        return save;
    }
}
