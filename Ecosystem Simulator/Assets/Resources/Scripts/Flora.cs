using System.Collections;
using System.Collections.Generic;
using UnityEngine;
  
public class Flora : Organism
{
    public float remainingNutrients;

    public override void kill()
    {
        // Create nutrients
        GameObject nutrients = Instantiate(Resources.Load("Prefabs/FloraNutrient") as GameObject, transform.position, Quaternion.identity);
        nutrients.GetComponent<Nutrients>().Init(nutrientValue);
        nutrients.transform.parent = transform.parent;


        // Then destroy the organism
        Destroy(gameObject);
    }

    public override void checkWater()
    {
        if (waterLevel <= 0f)
            kill();
    }

    public override void UpdateWater()
    {
        waterLevel -= 2f * Time.deltaTime;
        Collider[] nearby = Physics.OverlapSphere(gameObject.transform.position, (float)awareness);
        for (int i = 0; i < nearby.Length; i++)
        {
            if (nearby[i].gameObject.GetComponent("WaterSource"))
            {
                if (waterLevel <= 100f)
                    waterLevel += 8f * Time.deltaTime;
                break;
            }
        }
    }




}
