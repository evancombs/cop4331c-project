using System.Collections;
using System.Collections.Generic;
using UnityEngine;
  
public class Predator : Fauna
{
    double lethality;
    // Predators should only search for FaunaNutrients.
    public override void searchNutrients()
    {
        Collider[] nearby = Physics.OverlapSphere(gameObject.transform.position, (float)awareness);
        for (int i = 0; i < nearby.Length; i++)
        {
            if (nearby[i].gameObject.GetComponent("Nutrients"))
            {
                if (nutrientLevel <= 100f)
                    // this will be changed to get the specific value from the game object
                    nutrientLevel += consume(nearby[i].gameObject);

                break;
            }
        }
    }

    public float consume(GameObject nutrient)
    {
        nutrient.GetComponent<Nutrients>().consumeNutrients(consumptionRate);

        // Note: currently allows consumptionRate to still be added even if the consumption would reduce the nutrient to 0.
        return consumptionRate;
    }
}
