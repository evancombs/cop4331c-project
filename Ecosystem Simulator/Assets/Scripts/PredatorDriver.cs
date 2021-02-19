using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PredatorDriver : MonoBehaviour
{
    public Predator predatorInstance;
    public int xSize;
    public int zSize;
    // Start is called before the first frame update
    void Start()
    {
        predatorInstance = new Predator();
        predatorInstance.setMovementSpeed(5f);
    }

    // Update is called once per frame
    void Update()
    {
        // if (gameObject.transform.position.x > )
        gameObject.transform.Translate(predatorInstance.move() * new Vector3(Random.Range(-2f, 2f), 0, Random.Range(-2f, 2f)) * Time.deltaTime);
        //gameob
          //  predatorInstance.move
    }
}
