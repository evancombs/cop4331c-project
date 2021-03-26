using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SavedEcosystem
{
    public static SavedEcosystem current;
    // Static reference to current Ecosystem

    public List<SavedPrey> prey;
    public List<SavedPredator> predators;
    public List<SavedFlora> flora;
    public List<GameObject> waterSources;
    public List<GameObject> nutrients;

    public SavedEcosystem()
    {
        prey = new List<SavedPrey>();
        predators = new List<SavedPredator>();
        flora = new List<SavedFlora>();
        waterSources = new List<GameObject>();
        nutrients = new List<GameObject>();
    }

    public void addFlora(SavedFlora floraToAdd)
    {
        flora.Add(floraToAdd);
    }
    public void addPrey(SavedPrey preyToAdd)
    {
        prey.Add(preyToAdd);
    }
    public void addPredator(SavedPredator predatorToAdd)
    {
        predators.Add(predatorToAdd);
    }

    public void addNutrient(GameObject nutrient)
    {
        nutrients.Add(nutrient);
    }

    public void addWaterSource(GameObject water)
    {
        waterSources.Add(water);
    }

}
