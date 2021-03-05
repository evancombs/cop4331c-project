using System.Collections;
using System.Collections.Generic;
using UnityEngine;
  
public class Prey : Fauna
{
    bool consumeFlora;

    // Find a nutrient object within awareness.
    // Prey should only search for FloraNutrients
    public override void searchNutrients()
    {
        Collider[] nearby = Physics.OverlapSphere(gameObject.transform.position, (float)awareness);
        for (int i = 0; i < nearby.Length; i++)
        {
            if (nearby[i].gameObject.GetComponent("FloraNutrients"))
            {
                if (nutrientLevel <= 100f)
                    // this will be changed to get the specific value from the game object
                    nutrientLevel += consume(nearby[i].gameObject);

                break;
            }
        }
    }

    // Consumes some of the passed in nutrient object; returns the value consumed.
    public float consume(GameObject nutrient)
    {
        nutrient.GetComponent<FloraNutrient>().consumeNutrients(consumptionRate);

        // Note: currently allows consumptionRate to still be added even if the consumption would reduce the nutrient to 0.
        return consumptionRate;
    }
}
