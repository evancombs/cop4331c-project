using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrganismDriver : MonoBehaviour
{
    // Start is called before the first frame update
    public Organism organism;

    void Start()
    {
        organism = new Prey();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
