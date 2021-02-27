using System.Collections;
using System.Collections.Generic;
using UnityEngine;
  
public class Organism : MonoBehaviour
{    
    public float waterLevel;
    int nutrientValue;

    double reproductiveChance;
    int reproductiveRate;

    double awareness;


    public void kill()
    {
        // Create nutrients
        GameObject nutrients = Instantiate(Resources.Load("Prefabs/Nutrients") as GameObject, transform.position, Quaternion.identity);
        nutrients.GetComponent<Nutrients>().Init(nutrientValue);
        nutrients.transform.parent = transform.parent;

        // Then destroy the organism
        Destroy(gameObject);

    }
}
