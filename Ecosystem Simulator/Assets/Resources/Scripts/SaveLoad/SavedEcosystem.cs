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
    public List<SavedWater> waterSources;
    public List<SavedFaunaNutrient> faunaNutrients;
    public List<SavedFloraNutrient> floraNutrients;

    public SavedEcosystem()
    {
        prey = new List<SavedPrey>();
        predators = new List<SavedPredator>();
        flora = new List<SavedFlora>();
        waterSources = new List<SavedWater>();
        faunaNutrients = new List<SavedFaunaNutrient>();
        floraNutrients = new List<SavedFloraNutrient>();
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

    public void addFaunaNutrient(SavedFaunaNutrient nutrient)
    {
        faunaNutrients.Add(nutrient);
    }
    public void addFloraNutrient(SavedFloraNutrient nutrient)
    {
        floraNutrients.Add(nutrient);
    }

    public void addWaterSource(SavedWater water)
    {
        waterSources.Add(water);
    }

}
