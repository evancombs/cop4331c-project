using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SavedFauna : SavedOrganism
{
    float movementSpeed;
    float controlSpeed;

    public float consumptionRate;
    public float movementConsumptionRate;
    public float nutrientLevel;
}
