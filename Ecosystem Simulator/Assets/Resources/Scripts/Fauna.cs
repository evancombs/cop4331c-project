using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fauna : Organism
{
    private GameObject fauna;
    int hasHitEdge = 0;

    float movementSpeed = 5f;
    float controlSpeed = 1f;

    public float consumptionRate = 1f; // Flat water consumption
    public float movementConsumptionRate = 1f; // Dynamic nutrient consumption
    public float nutrientLevel;

  float directionDuration;
    private Vector3 directionVector;

    private void Start()
    {
        directionVector = new Vector3(Random.Range(-2f, 2f), 0, Random.Range(-2f, 2f));
        directionDuration = Random.Range(0, 5f);
        controlSpeed = Random.Range(0f, 1f);
        waterLevel = 50.0f;
				nutrientLevel = 50f;
    }

    public override void move()
    {
        directionDuration -= Time.deltaTime;


        // Generate a random direction
        if (directionDuration <= 0)
        {
            directionVector = new Vector3(Random.Range(-2f, 2f), 0, Random.Range(-2f, 2f));
            directionDuration = 5f;
            controlSpeed = Random.Range(0f, 1f);
        }

        if (hasHitEdge == 1)
        {
            directionVector = new Vector3(Random.Range(-2f, 2f), 0, Random.Range(-2f, 2f));
            directionDuration = 5f;
            controlSpeed = Random.Range(0f, 1f);
            hasHitEdge = 0;
        }


        directionVector.Normalize();

        
        Vector3 moveVector = (directionVector * Time.deltaTime * movementSpeed * controlSpeed);
        Vector3 nextPosition = (transform.position + moveVector);


        // Debug.Log("Next position is: " + nextPosition);
        if (nextPosition.x >= transform.parent.gameObject.GetComponent<Ecosystem>().xSize)
        {
            moveVector *= -1;
            Debug.Log("X BOUNCE");
            hasHitEdge = 1;
        }
        if(nextPosition.x <= 0)
        {
            moveVector *= -1;
            Debug.Log("X BOUNCE");
            hasHitEdge = 1;
        }
        if (nextPosition.z >= transform.parent.gameObject.GetComponent<Ecosystem>().zSize)
        {
            moveVector *= -1;
            Debug.Log("Z BOUNCE");
            hasHitEdge = 1;
        }
        if(nextPosition.z <= 0)
        {
            moveVector *= -1;
            Debug.Log("Z BOUNCE");
            hasHitEdge = 1;
        }

        // Debug.Log("Translating to: " + moveVector);
        // Debug.Log("Translating to " + direction * Time.deltaTime * movementSpeed);
        if (waterLevel <= 25)
        {
            GameObject closest = null; ;
            float minDist = Mathf.Infinity;
            Vector3 curPos = transform.position;
            Transform tMin = null;
            foreach (GameObject gameObj in GameObject.FindObjectsOfType<GameObject>())
            {
                if (gameObj.name == "WaterSource(Clone)")
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
            if (minDist > awareness)
            {
                transform.Translate(moveVector);
            }
            else
            {
                transform.LookAt(closest.transform);
                transform.position += transform.forward * Time.deltaTime * movementSpeed;
            }
        }
        else if (nutrientLevel <= 25)
        {
            GameObject closest = null; ;
            float minDist = Mathf.Infinity;
            Vector3 curPos = transform.position;
            Transform tMin = null;
            foreach (GameObject gameObj in GameObject.FindObjectsOfType<GameObject>())
            {
                if (gameObj.name == "FloraNutrient(Clone)" || gameObj.name == "FuanaNutrient(Clone)" || gameObj.name == "Flora(Clone)")
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
            if (minDist > awareness)
            {
                transform.Translate(moveVector);
            }
            else
            {
                transform.LookAt(closest.transform);
                transform.position += transform.forward * Time.deltaTime * movementSpeed;
            }
        }
        else
        {
            transform.Translate(moveVector);
        }
    }

    public override void UpdateNutrients()
    {
      if (nutrientLevel > 0)
        nutrientLevel -= movementConsumptionRate * controlSpeed * Time.deltaTime;

      Collider[] nearby = Physics.OverlapSphere(gameObject.transform.position, (float)awareness);
      for (int i = 0; i < nearby.Length; i++)
      {
        if (nearby[i].gameObject.GetComponent("Nutrients"))
        {
          if (nutrientLevel <= 100f)
            // this will be changed to get the specific value from the game object
            nutrientLevel += .2f * Time.deltaTime;

          break;
        }
      }
    }

  public override void UpdateWater()
  {
    waterLevel -= consumptionRate * Time.deltaTime;
    Collider[] nearby = Physics.OverlapSphere(gameObject.transform.position, (float)awareness);
    for (int i = 0; i < nearby.Length; i++)
    {
      if (nearby[i].gameObject.GetComponent("WaterSource"))
      {
        if (waterLevel <= 100f)
          // Number "5" arbitrary, corresponds with spending 1/4 of their lifespan drinking water
          waterLevel += 5f * Time.deltaTime; 
        break;
      }
    }
  }

  public override void checkWater()
    {
        if (waterLevel <= 0f)
            kill();
    }

	public override void checkNutrients()
	{
		if (nutrientLevel <= 0f && waterLevel <= 20f)
			kill();
	}

    public override void kill()
    {
        // Create nutrients
        GameObject nutrients = Instantiate(Resources.Load("Prefabs/FaunaNutrient") as GameObject, transform.position, Quaternion.identity);
        nutrients.GetComponent<Nutrients>().Init(nutrientValue);
        nutrients.transform.parent = transform.parent;


        // Then destroy the organism
        Destroy(gameObject);
    }

    
    
        



}
