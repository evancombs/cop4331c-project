using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavedFaunaNutrient : SavedNutrient
{
     public static GameObject loadNutrient(SavedFaunaNutrient nutrientSave)
    {
        GameObject loadedNutrient = GameObject.CreatePrimitive(PrimitiveType.Cube);

        FaunaNutrient nutrientscriptRef = loadedNutrient.AddComponent<FaunaNutrient>();
        loadedNutrient.GetComponent<MeshRenderer>().material = (Resources.Load("Materials/FaunaNutrient", typeof(Material)) as Material);

        loadedNutrient.transform.localScale = new Vector3(1f, 1f, 1f);
        loadedNutrient.transform.position = nutrientSave.savedTransform.position;

        nutrientscriptRef.remainingNutrients = nutrientSave.remainingNutrients;

        return loadedNutrient;
    }

    public static SavedFaunaNutrient SaveNutrient(GameObject nutrientObject)
    {
        FaunaNutrient nutrientscriptRef = nutrientObject.GetComponent<FaunaNutrient>();
        SavedFaunaNutrient nutrientSave = new SavedFaunaNutrient();

        nutrientSave.savedTransform = nutrientObject.transform;

        nutrientSave.remainingNutrients = nutrientscriptRef.remainingNutrients;

        return nutrientSave;
    }

}
