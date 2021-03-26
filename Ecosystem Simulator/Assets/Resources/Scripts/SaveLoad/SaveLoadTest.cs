using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveLoadTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject[] flora = GameObject.FindGameObjectsWithTag("flora");
        SavedFlora testSave = SavedFlora.saveFlora(flora[0]);

        GameObject testLoad = SavedFlora.loadFlora(testSave);
        Instantiate(testLoad);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
