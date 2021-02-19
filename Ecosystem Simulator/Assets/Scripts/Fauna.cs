using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fauna : Organism
{
    float movementSpeed;
    int nutritionLevel;

    public void setMovementSpeed(float movementSpeed)
    {
        this.movementSpeed = movementSpeed;
    }

    // Take a returns the movement speed of this organism
    public float move()
    {
        return movementSpeed;
    }
}
