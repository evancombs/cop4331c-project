using System.Collections;
using System.Collections.Generic;
using UnityEngine;
  
public class Nutrients : MonoBehaviour
{
    public float remainingNutrients;

    public void Init(float value)
    {
        value = 20;
        remainingNutrients = value;
    }

    private void Update()
    {
        UpdateSize();

        if (remainingNutrients <= 0)
            Destroy(gameObject);
    }

    // Removes amountConsumed from the remainingNutrients of this Nutrient
    public void consumeNutrients(float amountConsumed)
    {
        remainingNutrients -= amountConsumed;
    }

    public void UpdateSize()
    {
        // Maps the remainingNutrients [0, 100] range to a size range of [.25, 1.0]
        float modelSize = (remainingNutrients * .0175f) + .25f;

        Vector3 size = new Vector3(modelSize, modelSize, modelSize);
        gameObject.transform.localScale = size;
    }


}
