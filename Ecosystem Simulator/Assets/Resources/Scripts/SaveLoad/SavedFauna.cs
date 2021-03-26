using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SavedFauna : SavedOrganism
{
    public float movementSpeed;
    public float controlSpeed;

    public float consumptionRate;
    public float movementConsumptionRate;
    public float nutrientLevel;
}
