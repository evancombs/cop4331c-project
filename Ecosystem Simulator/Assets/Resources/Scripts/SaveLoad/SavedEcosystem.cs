using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SavedEcosystem
{
    public static SavedEcosystem current;
    // Static reference to current Ecosystem

    List<GameObject> organisms;
    List<GameObject> waterSources;
    List<GameObject> nutrients;

    public SavedEcosystem()
    {
        organisms = new List<GameObject>();
        waterSources = new List<GameObject>();
        nutrients = new List<GameObject>();
    }

    public void addOrganism(GameObject organism)
    {
        organisms.Add(organism);
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
