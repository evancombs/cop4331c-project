using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// The most basic entity unit of the ecosystem
public class Organism
{
    private int maxHealth;
    private int currentHealth;
    private int waterLevel;

    private int nutritionValue;

    private float reproductiveRate;


    private int age;
    // Add model 

    public Organism()
    {

    }
    public Organism(int maxHealth, int nutritionValue)
    {
        this.age = 0;
        this.maxHealth = maxHealth;
        this.currentHealth = maxHealth;
    }

    // Add common organism functions, kill(), grow() ? etc.

    // Organisms are not MonoBehavior objects; OrganismUpdate() should be called on every 
    // gametick by Unity Update() function
    public void OrganismUpdate()
    {

    }

    // Kill and destroy this organism.
    public void kill()
    {

    }

    // Deal damageValue amount of damage to this organism, subtracting that from currentHealth
    public void dealDamage(int damageValue)
    {

    }

    // Attempts to reproduce according to reproductive rate;
    // Randomly generates to see if reproduction is succesful, and how much so
    // Returns the number of organisms born as a result
    public int reproduce()
    {
        return 0;
    }


    // Getters
    public int getCurrentHealth()
    {
        return this.currentHealth;
    }
}
