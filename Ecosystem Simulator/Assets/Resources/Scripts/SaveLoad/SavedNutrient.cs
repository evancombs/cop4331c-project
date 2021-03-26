using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SavedNutrient
{
    // 0 = flora nutrient
    // 1 = fauna nutrient
    public float remainingNutrients;
    public Transform savedTransform;
}
