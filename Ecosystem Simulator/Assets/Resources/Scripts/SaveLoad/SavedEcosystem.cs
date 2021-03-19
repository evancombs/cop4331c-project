using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SavedEcosystem
{
    public static SavedEcosystem current;
    // Static reference to current Ecosystem

    List<SavedOrganism> organisms;
    List<GameObject> waterSources;
    List<GameObject> nutrients;

}
