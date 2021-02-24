using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fauna : Organism
{
    float movementSpeed = 5f;
    int nutritionLevel;

    float directionDuration;
    private Vector3 directionVector;

    int hasHitBarrier = 0;

    private void Start()
    {
        directionVector = new Vector3(Random.Range(-2f, 2f), 0, Random.Range(-2f, 2f));
        directionDuration = Random.Range(0, 5f);
        waterLevel = 50;
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

        if(hasHitBarrier == 1)
        {
            directionVector = new Vector3(Random.Range(-2f, 2f), 0, Random.Range(-2f, 2f));
            directionDuration = 5f;
            hasHitBarrier = 0;
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
            moveVector *= -1;
            Debug.Log("X BOUNCE");
            hasHitBarrier = 1;
        }
        else if (nextPosition.z >= transform.parent.gameObject.GetComponent<Ecosystem>().zSize
            || nextPosition.z <= 0)
        {
            moveVector *= -1;
            Debug.Log("Z BOUNCE");
            hasHitBarrier = 1;
        }
        
        // Debug.Log("Translating to " + direction * Time.deltaTime * movementSpeed);
        transform.Translate(moveVector);
    }
}
