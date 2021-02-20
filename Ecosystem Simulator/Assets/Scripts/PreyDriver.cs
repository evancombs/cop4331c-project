using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreyDriver : MonoBehaviour
{
    public Prey preyInstance;

    public int xSize;
    public int zSize;
    // Start is called before the first frame update
    void Start()
    {
        // preyInstance = new Prey();
        // preyInstance.setMovementSpeed(5f);
    }

    // Update is called once per frame
    void Update()
    {
        // gameObject.transform.Translate(preyInstance.move() * new Vector3(Random.Range(-2f, 2f), 0, Random.Range(-2f, 2f)) * Time.deltaTime);
    }
}
