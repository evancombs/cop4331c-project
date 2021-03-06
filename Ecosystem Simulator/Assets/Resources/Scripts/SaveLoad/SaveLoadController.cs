﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine.UI;

public class SaveLoadController : MonoBehaviour
{
    //public static List<SavedEcosystem> savedEcosystems = new List<SavedEcosystem>();
    //public static SavedEcosystem savedEco1, savedEco2, savedEco3;
    public static SavedEcosystem[] savedEcosystems = new SavedEcosystem[3];
    public Button saveButton, loadButton;
    public Button save1, save2, save3;
    public Button load1, load2, load3;
    public static GameObject ecosystem;
    public bool saveUIDisplayed, loadUIDisplayed;
    public GameObject saveUIPanel, loadUIPanel;


    private void Start()
    {
        saveButton.onClick.AddListener(displaySaveUI);
        loadButton.onClick.AddListener(displayLoadUI);

        saveUIPanel.SetActive(false);
        loadUIPanel.SetActive(false);

        save1.onClick.AddListener(Save1);
        save2.onClick.AddListener(Save2);
        save3.onClick.AddListener(Save3);

        load1.onClick.AddListener(Load1);
        load2.onClick.AddListener(Load2);
        load3.onClick.AddListener(Load3);
        ecosystem = GameObject.FindGameObjectWithTag("ecosystem");
    }

    // Info Source: https://gamedevelopment.tutsplus.com/tutorials/how-to-save-and-load-your-players-progress-in-unity--cms-20934
    public static void Save(int saveSlot)
    {
        // Get current Ecosystem to save
        savedEcosystems[saveSlot] = getCurrentEcosystem();
        
        // BinaryFormatter handles Serialization/Deserialization
        BinaryFormatter bf = new BinaryFormatter();

        // Get a file stream to save to. Application.persistenDataPath is a 
        // useful Unity reference that adapts to how you build game
        FileStream file = File.Create(Application.persistentDataPath + "/savedEcosystems.es");
        Debug.Log("Saved to: " + Application.persistentDataPath + "/savedEcosystems.es");
        //FileStream file = File.Create(@"c:\UnitySaveTest");
        bf.Serialize(file, SaveLoadController.savedEcosystems);
        file.Close();
    }



    public static void Load(int saveSlot)
    {
        if (File.Exists(Application.persistentDataPath + "/savedEcosystems.es"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/savedEcosystems.es", FileMode.Open);
            SaveLoadController.savedEcosystems = (SavedEcosystem[])bf.Deserialize(file);
            file.Close();
        }
        loadEntireEcosystem(savedEcosystems[saveSlot]);
    }
    // Functions for each button. Yes this sucks, I know.
    public static void Save1()
    {
        Save(0);
    }
    public static void Save2()
    {
        Save(1);
    }
    public static void Save3()
    {
        Save(2);
    }
    public static void Load1()
    {
        Load(0);
    }
    public static void Load2()
    {
        Load(1);
    }
    public static void Load3()
    {
        Load(2);
    }

    // This function nukes the entire ecosystem and reinstantiates everything based
    // on the SavedEcosystem passed in
    public static void loadEntireEcosystem(SavedEcosystem saveToLoad)
    {
        // Clear the old, to make way for the new
        destroyEcosystem();
        
        Debug.Log("Loading " + saveToLoad.waterSources.Count + " water sources!");

        // Now we loop through the lists in the SavedEcosystem to instantiate them into the simulation
        for (int i = 0; i < saveToLoad.prey.Count; i++)
        {
            GameObject tempPrey = Instantiate(SavedPrey.loadPrey(saveToLoad.prey[i]));
            tempPrey.transform.parent = ecosystem.transform;
        }

        for (int i = 0; i < saveToLoad.predators.Count; i++)
        {
            GameObject tempPred = Instantiate(SavedPredator.loadPredator(saveToLoad.predators[i]));
            tempPred.transform.parent = ecosystem.transform;
            
        }

        for (int i = 0; i < saveToLoad.flora.Count; i++)
        {
            GameObject tempFlora = Instantiate(SavedFlora.loadFlora(saveToLoad.flora[i]));
            tempFlora.transform.parent = ecosystem.transform;
            
        }
        for (int i = 0; i < saveToLoad.floraNutrients.Count; i++)
        {
            GameObject tempNutrients = Instantiate(SavedFloraNutrient.loadNutrient(saveToLoad.floraNutrients[i]));
            tempNutrients.transform.parent = ecosystem.transform;
        }
        for (int i = 0; i < saveToLoad.faunaNutrients.Count; i++)
        {
            GameObject tempNutrients = Instantiate(SavedFaunaNutrient.loadNutrient(saveToLoad.faunaNutrients[i]));
            tempNutrients.transform.parent = ecosystem.transform;
        }

        for (int i = 0; i < saveToLoad.waterSources.Count; i++)
        {
            GameObject tempWater = Instantiate(Resources.Load("Prefabs/WaterSource") as GameObject, SavedWater.loadWaterPos(saveToLoad.waterSources[i]), Quaternion.identity);
            tempWater.transform.parent = ecosystem.transform;
            tempWater.tag = "waterSource";
        }
    }

    // Destroys all children of this Ecosystem
    public static void destroyEcosystem()
    {
        /*
        foreach (Transform child in ecosystem.transform)
            GameObject.Destroy(child.gameObject);
        */
        foreach (GameObject gameObj in GameObject.FindObjectsOfType<GameObject>())
        {
            if (gameObj.transform.parent == ecosystem.transform)
                Destroy(gameObj);
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
            save.addFaunaNutrient(SavedFaunaNutrient.SaveNutrient(faunaNutrients[i]));
        for (int i = 0; i < floraNutrients.Length; i++)
            save.addFloraNutrient(SavedFloraNutrient.SaveNutrient(floraNutrients[i]));

        // Water
        for (int i = 0; i < waterSources.Length; i++)
            save.addWaterSource(SavedWater.saveWater(waterSources[i]));

        // Organisms
        // Here we have "gathered" all of the organism GameObjects. We use
        // the save[organism]() functions for each respective organism to convert it to
        // a saveable (serializable) class and add it to our list of SavedOrganisms.
        for (int i = 0; i < prey.Length; i++)
            save.addPrey(SavedPrey.savePrey(prey[i]));
        for (int i = 0; i < predators.Length; i++)
            save.addPredator(SavedPredator.savePredator(predators[i]));
        for (int i = 0; i < flora.Length; i++)
            save.addFlora(SavedFlora.saveFlora(flora[i]));

        Debug.Log("Finished profile save! Returning to Save()");
        return save;
    }

    public void displaySaveUI()
    {
        saveUIDisplayed = !saveUIDisplayed;
        loadUIPanel.SetActive(false);
        if (saveUIDisplayed)
            saveUIPanel.SetActive(true);
        else
            saveUIPanel.SetActive(false);
        loadUIPanel.SetActive(false);
        loadUIDisplayed = false;
    }

    public void displayLoadUI()
    {
        loadUIDisplayed = !loadUIDisplayed;
        
        if (loadUIDisplayed)
            loadUIPanel.SetActive(true);
        else
            loadUIPanel.SetActive(false);
        saveUIPanel.SetActive(false);
        saveUIDisplayed = false;
    }
}
