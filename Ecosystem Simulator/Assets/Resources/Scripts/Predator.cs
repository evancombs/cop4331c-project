using System.Collections;
using System.Collections.Generic;
using UnityEngine;
  
public class Predator : Fauna
{
    public double lethality;
    // Predators should only search for FaunaNutrients.
    public override void searchNutrients()
    {
        Collider[] nearby = Physics.OverlapSphere(gameObject.transform.position, (float)awareness);
        for (int i = 0; i < nearby.Length; i++)
        {
            if (nearby[i].gameObject.GetComponent("FaunaNutrient"))
            {
                if (nutrientLevel <= 100f)
                    // this will be changed to get the specific value from the game object
                    nutrientLevel += consume(nearby[i].gameObject) * Time.deltaTime;

                break;
            }
        }
    }

    public float consume(GameObject nutrient)
    {
        nutrient.GetComponent<Nutrients>().consumeNutrients(consumptionRate);
        if(lookingForNutrients == true)
        {
            GameObject closest = null; ;
            float minDist = Mathf.Infinity;
            Vector3 curPos = transform.position;
            Transform tMin = null;
            foreach (GameObject gameObj in GameObject.FindObjectsOfType<GameObject>())
            {
                if (gameObj.name.StartsWith("Prey"))
                {
                    float dist = Vector3.Distance(gameObj.transform.position, curPos);
                    if (dist < minDist)
                    {
                        tMin = gameObj.transform;
                        minDist = dist;
                        closest = gameObj;
                    }
                }
            }
            if(minDist < 5f)
            {
                Debug.Log("Killed Prey");
                Destroy(closest);
            }
        }
        // Note: currently allows consumptionRate to still be added even if the consumption would reduce the nutrient to 0.
        return consumptionRate;
    }
}
