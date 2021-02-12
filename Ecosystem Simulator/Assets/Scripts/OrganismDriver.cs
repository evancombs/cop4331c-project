using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrganismDriver : MonoBehaviour
{
    // Start is called before the first frame update
    public Organism organism;
    public int test;
    void Start()
    {
        // organism = new Predator();
    }

    // Update is called once per frame
    void Update()
    {
        // organism.OrganismUpdate();
        if (organism.getCurrentHealth() < 0)
        {
            organism.kill();
            Destroy(gameObject);
        }
          
    }
}
