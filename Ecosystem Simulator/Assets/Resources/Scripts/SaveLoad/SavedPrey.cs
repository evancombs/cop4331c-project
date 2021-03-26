using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SavedPrey : SavedFauna
{
    public static GameObject loadPrey(SavedPrey preySave)
    {
        // We are essentially building the Predator object from scratch here.
        GameObject loadedPrey = GameObject.CreatePrimitive(PrimitiveType.Cube);

        Predator preyScriptRef = loadedPrey.AddComponent<Predator>();

        loadedPrey.GetComponent<MeshRenderer>().material = (Resources.Load("Materials/Red", typeof(Material)) as Material);

        loadedPrey.transform.localScale = new Vector3(1f, 1f, 1f);
        loadedPrey.transform.position = preySave.savedTransform.position;

        preyScriptRef.waterLevel = preySave.waterLevel;
        preyScriptRef.nutrientValue = preySave.nutrientValue;
        preyScriptRef.reproductiveChance = preySave.reproductiveChance;
        preyScriptRef.reproductiveRate = preySave.reproductiveRate;
        preyScriptRef.awareness = preySave.awareness;
        preyScriptRef.transform.position = preySave.savedTransform.position;

        preyScriptRef.movementSpeed = preySave.movementSpeed;
        preyScriptRef.controlSpeed = preySave.controlSpeed;
        preyScriptRef.consumptionRate = preySave.consumptionRate;
        preyScriptRef.movementConsumptionRate = preySave.movementConsumptionRate;
        preyScriptRef.nutrientLevel = preySave.nutrientLevel;

        return loadedPrey;
    }

    public static SavedPrey savePrey(GameObject preyObject)
    {
        Prey preyScriptRef = preyObject.GetComponent<Prey>();
        SavedPrey preySave = new SavedPrey();

        preySave.savedTransform = preyObject.transform;

        preySave.waterLevel = preyScriptRef.waterLevel;
        preySave.nutrientValue = preyScriptRef.nutrientValue;
        preySave.reproductiveChance = preyScriptRef.reproductiveChance;
        preySave.reproductiveRate = preyScriptRef.reproductiveRate;
        preySave.awareness = preyScriptRef.awareness;
        preySave.savedTransform = preyScriptRef.transform;

        preySave.movementSpeed = preyScriptRef.movementSpeed;
        preySave.controlSpeed = preyScriptRef.controlSpeed;
        preySave.consumptionRate = preyScriptRef.consumptionRate;
        preySave.movementConsumptionRate = preyScriptRef.movementConsumptionRate;
        preySave.nutrientLevel = preyScriptRef.nutrientLevel;

        return preySave;
    }
}
