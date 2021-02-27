using System.Collections;
using System.Collections.Generic;
using UnityEngine;
    
public class Fauna : Organism
{
    private GameObject fauna;
    int hasHitEdge = 0;

    float movementSpeed = 5f;
    int nutritionLevel;

    float directionDuration;
    private Vector3 directionVector;

    private void Start()
    {
        directionVector = new Vector3(Random.Range(-2f, 2f), 0, Random.Range(-2f, 2f));
        directionDuration = Random.Range(0, 5f);
        waterLevel = 50.0f;
    }

    public override void move()
    {
        directionDuration -= Time.deltaTime;

        
        // Generate a random direction
        if (directionDuration <= 0)
        {
            directionVector = new Vector3(Random.Range(-2f, 2f), 0, Random.Range(-2f, 2f));
            directionDuration = 5f;
        }

        if(hasHitEdge == 1)
        {
            directionVector = new Vector3(Random.Range(-2f, 2f), 0, Random.Range(-2f, 2f));
            directionDuration = 5f;
            hasHitEdge = 0;
        }

        directionVector.Normalize();
        
        Vector3 moveVector = (directionVector * Time.deltaTime * movementSpeed);
        Vector3 nextPosition = (transform.position + moveVector);
        
        // Debug.Log("Next position is: " + nextPosition);

        if (nextPosition.x >= transform.parent.gameObject.GetComponent<Ecosystem>().xSize
            || nextPosition.x <= 0)
        {
            moveVector *= -1;
            Debug.Log("X BOUNCE");
            hasHitEdge = 1;
        }
        if (nextPosition.z >= transform.parent.gameObject.GetComponent<Ecosystem>().zSize
            || nextPosition.z <= 0)
        {
            moveVector *= -1;
            Debug.Log("Z BOUNCE");
            hasHitEdge = 1;
        }

        // Debug.Log("Translating to: " + moveVector);
        // Debug.Log("Translating to " + direction * Time.deltaTime * movementSpeed);
        transform.Translate(moveVector);
    }
}
