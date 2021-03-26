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
        // We are essentially building the Flora object from scratch here.
        GameObject loadedFlora = GameObject.CreatePrimitive(PrimitiveType.Cube);
        
        Flora floraScriptRef = loadedFlora.AddComponent<Flora>();
        
        loadedFlora.GetComponent<MeshRenderer>().material = (Resources.Load("Materials/Green", typeof(Material)) as Material);

        loadedFlora.transform.localScale = new Vector3(.25f, 3f, .25f);
        loadedFlora.transform.position = floraSave.savedTransform.position;

        floraScriptRef.waterLevel = floraSave.waterLevel;
        floraScriptRef.nutrientValue = floraSave.nutrientValue;
        floraScriptRef.reproductiveChance = floraSave.reproductiveChance;
        floraScriptRef.reproductiveRate = floraSave.reproductiveRate;
        floraScriptRef.awareness = floraSave.awareness;
        floraScriptRef.remainingNutrients = floraSave.remainingNutrients;
        floraScriptRef.transform.position = floraSave.savedTransform.position;

        return loadedFlora;
    }

    // Takes a GameObject in a scene and returns a SavedFlora storing it
    public static SavedFlora saveFlora(GameObject floraObject)
    {
        Flora floraScriptRef = floraObject.GetComponent<Flora>();
        SavedFlora floraSave = new SavedFlora();

        floraSave.savedTransform = floraObject.transform;

        floraSave.waterLevel = floraScriptRef.waterLevel;
        floraSave.nutrientValue = floraScriptRef.nutrientValue;
        floraSave.reproductiveChance = floraScriptRef.reproductiveChance;
        floraSave.reproductiveRate = floraScriptRef.reproductiveRate;
        floraSave.awareness = floraScriptRef.awareness;
        floraSave.remainingNutrients = floraScriptRef.remainingNutrients;
        
        return floraSave;
    }
}


