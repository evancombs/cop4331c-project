using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavedFloraNutrient : SavedNutrient
{
    public static GameObject loadNutrient(SavedFloraNutrient nutrientSave)
    {
        GameObject loadedNutrient = GameObject.CreatePrimitive(PrimitiveType.Cube);

        FloraNutrient nutrientscriptRef = loadedNutrient.AddComponent<FloraNutrient>();
        loadedNutrient.GetComponent<MeshRenderer>().material = (Resources.Load("Materials/FaunaNutrient", typeof(Material)) as Material);

        loadedNutrient.transform.localScale = new Vector3(1f, 1f, 1f);
        loadedNutrient.transform.position = nutrientSave.savedTransform.position;

        nutrientscriptRef.remainingNutrients = nutrientSave.remainingNutrients;

        return loadedNutrient;
    }

    public static SavedFloraNutrient SaveNutrient(GameObject nutrientObject)
    {
        FloraNutrient nutrientscriptRef = nutrientObject.GetComponent<FloraNutrient>();
        SavedFloraNutrient nutrientSave = new SavedFloraNutrient();

        nutrientSave.savedTransform = nutrientObject.transform;

        nutrientSave.remainingNutrients = nutrientscriptRef.remainingNutrients;

        return nutrientSave;
    }
}
