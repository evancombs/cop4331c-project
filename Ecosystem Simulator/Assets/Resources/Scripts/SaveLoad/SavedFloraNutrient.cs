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

        Vector3 pos = new Vector3(nutrientSave.xCoord, nutrientSave.yCoord, nutrientSave.zCoord);
        loadedNutrient.transform.position = pos;


        nutrientscriptRef.remainingNutrients = nutrientSave.remainingNutrients;

        return loadedNutrient;
    }

    public static SavedFloraNutrient SaveNutrient(GameObject nutrientObject)
    {
        FloraNutrient nutrientscriptRef = nutrientObject.GetComponent<FloraNutrient>();
        SavedFloraNutrient nutrientSave = new SavedFloraNutrient();

        nutrientSave.xCoord = nutrientObject.transform.position.x;
        nutrientSave.yCoord = nutrientObject.transform.position.y;
        nutrientSave.zCoord = nutrientObject.transform.position.z;

        nutrientSave.remainingNutrients = nutrientscriptRef.remainingNutrients;

        return nutrientSave;
    }
}
