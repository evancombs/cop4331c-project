using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Flora are imobile organisms that serve as food sources for predators/prey
public class Flora : MonoBehaviour
{
    public double waterLevel = 1;

    int maxHealth;
    int currentHealth;

    int nutrientValue;

    float reproductiveRate = 2.0f;

    public GameObject flora;
    

    // Start is called before the first frame update
    void Start()
    {
        waterLevel = 50;
    }

    // Update is called once per frame
    void Update()
    {
        // Check if there is a water source within 20 units
        waterLevel -= .1;
        Collider[] hits = Physics.OverlapSphere(transform.position, 20);
        for (int i = 0; i < hits.Length; i++)
        {
            if (hits[i].gameObject.GetComponent("WaterSource") != null)
                if (waterLevel < 100)
                    waterLevel += .2;
                else;
            

        }

        if (waterLevel >= 100)
            reproduce();
    }

    private int reproduce()
    {
        float chance = Random.Range(0, 1);
        if (chance > reproductiveRate)
            return 0;
        int n = (int)reproductiveRate;
        Debug.Log("Birthing " + n + " new entities!");
        float x, y, z;
        x = transform.position.x + Random.Range(-5f, 5f);
        y = transform.position.y;
        z = transform.position.z + Random.Range(-5f, 5);
        for (int i = 0; i < n; i++)
            Instantiate(flora, new Vector3(x, y, z), Quaternion.identity);
        waterLevel = 50;
        return n;
    }
}
