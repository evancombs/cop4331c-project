using System.Collections;
using System.Collections.Generic;
using UnityEngine;
  
public class Flora : Organism
{


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
}
