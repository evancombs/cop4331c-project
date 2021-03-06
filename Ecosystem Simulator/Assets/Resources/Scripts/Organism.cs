using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Organism : MonoBehaviour
{
    public float waterLevel;
    public float nutrientValue;

    double reproductiveChance;
    int reproductiveRate;

    public double awareness = 10;


    public virtual void kill()
    {
        // Create nutrients
        GameObject nutrients = Instantiate(Resources.Load("Prefabs/Nutrient") as GameObject, transform.position, Quaternion.identity);
        nutrients.GetComponent<Nutrients>().Init(nutrientValue);
        nutrients.transform.parent = transform.parent;


        // Then destroy the organism
        Destroy(gameObject);

    }

    public void Update()
    {
        // the Update() in organism should call all functions that organisms might need to do, even
        // if not all organism will use it; this is so classes that DO need these functions can override them,
        // instead of overriding Update();


        // Functions implemented here that all Organisms need:
        UpdateWater();
				UpdateNutrients();

        // Functions that some Organisms need:
        move();
        checkWater();
        checkNutrients();
        searchNutrients();
    }

    public virtual void UpdateWater()
    {
      waterLevel -= 0.1f * Time.deltaTime;
      Collider[] nearby = Physics.OverlapSphere(gameObject.transform.position, (float)awareness);
      for (int i = 0; i < nearby.Length; i++)
      {
        if (nearby[i].gameObject.GetComponent("WaterSource"))
        {
          if (waterLevel <= 100f)
            waterLevel += .2f * Time.deltaTime;
          break;
        }
      }
    }

	  

    // The base organism has no movement functionality; Fauna, however, does.
    public virtual void move()
    {

    }

    // The base organism has no ability to check water, but fauna does.
    public virtual void checkWater()
    {

    }

	public virtual void checkNutrients()
    {

    }

  public virtual void UpdateNutrients()
  {

  }

  public virtual void searchNutrients()
    {

    }

}
