using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SavedWater
{
    // This just stores the position
    public float xCoord, yCoord, zCoord;
    public static SavedWater saveWater(GameObject waterObject)
    {
        SavedWater waterSave = new SavedWater();

        waterSave.xCoord = waterObject.transform.position.x;
        waterSave.yCoord = waterObject.transform.position.y;
        waterSave.zCoord = waterObject.transform.position.z;

        return waterSave;
    }

    public static Vector3 loadWaterPos(SavedWater waterSave)
    {
        Vector3 pos = new Vector3(waterSave.xCoord, waterSave.yCoord, waterSave.zCoord);
        return pos;
    }
}
