using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SavedFlora : SavedOrganism
{
    public float remainingNutrients;

    // Takes a SavedFlora and returns a GameObject to be instantiated.
    public static GameObject loadFlora(SavedFlora floraSave)
    {
        GameObject loadedFlora = GameObject.CreatePrimitive(PrimitiveType.Cube);
        // We are essentially building the Flora object from scratch here.
        Flora floraScriptRef = loadedFlora.AddComponent<Flora>();
        loadedFlora.transform.localScale.Set(.25f, 3f, .25f);
        loadedFlora.GetComponent<MeshRenderer>().material = Resources.Load("Resources/Materials/Green") as Material;

        
        floraScriptRef.waterLevel = floraSave.waterLevel;
        floraScriptRef.nutrientValue = floraSave.nutrientValue;
        floraScriptRef.reproductiveChance = floraSave.reproductiveChance;
        floraScriptRef.reproductiveRate = floraSave.reproductiveRate;
        floraScriptRef.awareness = floraSave.awareness;
        floraScriptRef.remainingNutrients = floraSave.remainingNutrients;

        return loadedFlora;
    }

    // Takes a GameObject in a scene and returns a SavedFlora storing it
    public static SavedFlora saveFlora(GameObject floraObject)
    {

        return null;
    }
}


