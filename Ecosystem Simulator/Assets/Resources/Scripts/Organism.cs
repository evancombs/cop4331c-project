using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Organism : MonoBehaviour
{
    public float waterLevel;
    public float nutrientValue;

    public double reproductiveChance;
    public int reproductiveRate;

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
        checkReproduce();

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

    // Flora automatically try to reproduce and always have nutrients satisfied.
    public virtual void checkReproduce()
    {
        // Debug.Log("Checking reproductive ability!");
        bool waterSatisfied = false;
        bool nutrientSatisfied = true;

        if (waterLevel >= 25f)
            waterSatisfied = true;

        if (nutrientSatisfied && waterSatisfied)
            reproduce();
    }

    public virtual int reproduce()
    {
        // Debug.Log("Ready to try to reproduce!");
        float chanceToReproduce = Random.Range(0, 1);

        // If the chance fails, we instantly return 0
        if (chanceToReproduce >= reproductiveChance)
            return 0;

        // If we get here, reproduction has been succesful, so we must create
        // reproductiveRate new organisms.
        // We attempt to produce UP TO
        for (int i = 0; i < reproductiveRate; i++)
        {
            if ((waterLevel -= 25f) <= 0)
                break;
            // Random position within 10 units
            Vector3 pos = new Vector3(gameObject.transform.position.x + Random.Range(-10, 10),
                                      gameObject.transform.position.y,
                                      gameObject.transform.position.z + Random.Range(-10, 10));
            GameObject newChild = GameObject.Instantiate(gameObject as GameObject, pos, Quaternion.identity);
            // newChild.transform.parent = gameObject.transform.parent;
            newChild.transform.SetParent(gameObject.transform.parent);
            //Debug.Log(gameObject.transform.parent);
            waterLevel -= 25f;
        }

        return reproductiveRate;
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
