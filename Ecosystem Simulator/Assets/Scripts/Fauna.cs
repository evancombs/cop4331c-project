using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fauna : Organism
{
    float movementSpeed = 5f;
    int nutritionLevel;

    float directionDuration;
    private Vector3 directionVector;

    private void Start()
    {
        directionVector = new Vector3(Random.Range(-2f, 2f), 0, Random.Range(-2f, 2f));
        directionDuration = Random.Range(0, 5f);
    }
    private void Update()
    {
        directionDuration -= Time.deltaTime;

        // Debug.Log

        if (directionDuration <= 0)
        {
            directionVector = new Vector3(Random.Range(-2f, 2f), 0, Random.Range(-2f, 2f));
            directionDuration = 5f;
        }
        move(directionVector);
    }

    private void move(Vector3 direction)
    {
        //Vector3 currentPosition = gameObject.transform.position;
        Vector3 moveVector = (direction * Time.deltaTime * movementSpeed);
        Vector3 nextPosition = (transform.position + moveVector);
        // Debug.Log
        Debug.Log("Next position is: " + nextPosition);


        if (nextPosition.x >= transform.parent.gameObject.GetComponent<Ecosystem>().xSize
            || nextPosition.x <= 0)
        {
            moveVector *= -5;
            Debug.Log("X BOUNCE");
        }
        else if (nextPosition.z >= transform.parent.gameObject.GetComponent<Ecosystem>().zSize
            || nextPosition.z <= 0)
        {
            moveVector *= -5;
            Debug.Log("Z BOUNCE");
        }
        
        // Debug.Log("Translating to " + direction * Time.deltaTime * movementSpeed);
        transform.Translate(moveVector);
    }
}
