using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Flora are imobile organisms that serve as food sources for predators/prey
public class Flora : MonoBehaviour
{
    public double waterLevel = 10;

    int maxHealth;
    int currentHealth;

    int nutrientValue;

    float waterRetention = 1.5f;

    float reproductiveRate = 2.0f;

    public GameObject flora;
    

    // Start is called before the first frame update
    void Start()
    {
        waterLevel = Random.Range(25, 75);
        maxHealth = 100;
        currentHealth = 100;
    }

    // Update is called once per frame
    void Update()
    {
        // Check if this thing should be alive lol
        if (waterLevel <= 0)
            kill();
        if (currentHealth <= 0)
            kill();

        waterLevel -= .3;
        // Check nearby water sources and other flora
        bool nearbyWater = false;
        int nearbyFlora = 0;

        Collider[] hits = Physics.OverlapSphere(transform.position, 20);
        for (int i = 0; i < hits.Length; i++)
        {
            if (hits[i].gameObject.GetComponent("WaterSource") != null)
            {
                nearbyWater = true;
            }
            if (hits[i].gameObject.GetComponent("Flora") != null)
            {
                nearbyFlora++;
            }
        }
        Debug.Log(nearbyFlora + " nearby flora!");
        if (nearbyWater && waterLevel < 100)
            waterLevel += (.6 - (.01 * nearbyFlora));

        if (nearbyWater && waterLevel >= 100)
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

    // Kills this organism
    private void kill()
    {
        Debug.Log("Organism has died!");
        Destroy(gameObject);
    }
}
