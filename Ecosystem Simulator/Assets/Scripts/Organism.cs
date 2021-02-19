using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Organism
{
    int waterLevel;
    int nutrientValue;

    double reproductiveChance;
    int reproductiveRate;

    double awareness;

    public Organism()
    {
        // Default Value
        this.waterLevel = 50;
        this.nutrientValue = 10;
        this.reproductiveChance = 1;
        this.reproductiveRate = 1;
        this.awareness = 10.0;
    }

}
