using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SavedFaunaNutrient : SavedNutrient
{
     public static GameObject loadNutrient(SavedFaunaNutrient nutrientSave)
    {
        // GameObject loadedNutrient = GameObject.CreatePrimitive(PrimitiveType.Cube);
        GameObject loadedNutrient = Resources.Load("Prefabs/FaunaNutrient") as GameObject;

        FaunaNutrient nutrientscriptRef = loadedNutrient.GetComponent<FaunaNutrient>();
        // loadedNutrient.GetComponent<MeshRenderer>().material = (Resources.Load("Materials/FaunaNutrient", typeof(Material)) as Material);
        // loadedNutrient.tag = "faunaNutrient";

        // loadedNutrient.transform.localScale = new Vector3(1f, 1f, 1f);

        Vector3 pos = new Vector3(nutrientSave.xCoord, nutrientSave.yCoord, nutrientSave.zCoord);
        loadedNutrient.transform.position = pos;

        nutrientscriptRef.remainingNutrients = nutrientSave.remainingNutrients;

        return loadedNutrient;
    }

    public static SavedFaunaNutrient SaveNutrient(GameObject nutrientObject)
    {
        FaunaNutrient nutrientscriptRef = nutrientObject.GetComponent<FaunaNutrient>();
        SavedFaunaNutrient nutrientSave = new SavedFaunaNutrient();

        nutrientSave.xCoord = nutrientObject.transform.position.x;
        nutrientSave.yCoord = nutrientObject.transform.position.y;
        nutrientSave.zCoord = nutrientObject.transform.position.z;

        nutrientSave.remainingNutrients = nutrientscriptRef.remainingNutrients;

        return nutrientSave;
    }

}
