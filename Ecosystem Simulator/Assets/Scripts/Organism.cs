using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// The most basic entity unit of the ecosystem
public class Organism
{
    private int maxHealth;
    private int currentHealth;

    private int nutritionValue;

    private int age;
    // Add model 

    // Add common organism functions, kill(), grow() ? etc.

    // Organisms are not MonoBehavior objects; OrganismUpdate() should be called on every 
    // gametick by Unity Update() function
    public void OrganismUpdate()
    {

    }
    public Organism()
    {

    }
    public Organism(int maxHealth, int nutritionValue)
    {
        this.age = 0;
        this.maxHealth = maxHealth;
        this.currentHealth = maxHealth;
    }
}
