using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SavedPredator : SavedFauna
{
    public double lethality;

    public static GameObject loadPredator(SavedPredator predatorSave)
    {
        // We are essentially building the Predator object from scratch here.
        GameObject loadedPredator = GameObject.CreatePrimitive(PrimitiveType.Cube);

        Predator predScriptRef = loadedPredator.AddComponent<Predator>();

        loadedPredator.GetComponent<MeshRenderer>().material = (Resources.Load("Materials/Red", typeof(Material)) as Material);

        loadedPredator.transform.localScale = new Vector3(1f, 1f, 1f);
        loadedPredator.transform.position = predatorSave.savedTransform.position;

        predScriptRef.waterLevel = predatorSave.waterLevel;
        predScriptRef.nutrientValue = predatorSave.nutrientValue;
        predScriptRef.reproductiveChance = predatorSave.reproductiveChance;
        predScriptRef.reproductiveRate = predatorSave.reproductiveRate;
        predScriptRef.awareness = predatorSave.awareness;
        predScriptRef.lethality = predatorSave.lethality;
        predScriptRef.transform.position = predatorSave.savedTransform.position;

        predScriptRef.movementSpeed = predatorSave.movementSpeed;
        predScriptRef.controlSpeed = predatorSave.controlSpeed;
        predScriptRef.consumptionRate = predatorSave.consumptionRate;
        predScriptRef.movementConsumptionRate = predatorSave.movementConsumptionRate;
        predScriptRef.nutrientLevel = predatorSave.nutrientLevel;

        return loadedPredator;
    }

    public static SavedPredator savePredator(GameObject predatorObject)
    {
        Predator PredScriptRef = predatorObject.GetComponent<Predator>();
        SavedPredator predatorSave = new SavedPredator();

        predatorSave.savedTransform = predatorObject.transform;

        predatorSave.waterLevel = PredScriptRef.waterLevel;
        predatorSave.nutrientValue = PredScriptRef.nutrientValue;
        predatorSave.reproductiveChance = PredScriptRef.reproductiveChance;
        predatorSave.reproductiveRate = PredScriptRef.reproductiveRate;
        predatorSave.awareness = PredScriptRef.awareness;
        predatorSave.lethality = PredScriptRef.lethality;
        predatorSave.savedTransform = PredScriptRef.transform;

        predatorSave.movementSpeed = PredScriptRef.movementSpeed;
        predatorSave.controlSpeed = PredScriptRef.controlSpeed;
        predatorSave.consumptionRate = PredScriptRef.consumptionRate;
        predatorSave.movementConsumptionRate = PredScriptRef.movementConsumptionRate;
        predatorSave.nutrientLevel = PredScriptRef.nutrientLevel;

        return predatorSave;
    }
}
