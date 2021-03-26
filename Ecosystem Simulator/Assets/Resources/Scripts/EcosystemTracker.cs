using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EcosystemTracker : MonoBehaviour
{
  public GameObject ecosystem;
  public GameObject graph;

  public float updateRate;
  private float nextUpdate = 0;

  private Dictionary<string, int> data;
  
  // Start is called before the first frame update
  void Start()
  {
    
  }

  // Update is called once per frame
  void Update()
  {
    if (nextUpdate < Time.time)
    {
      CountOrganisms();
      GraphOrganisms();
      nextUpdate = Time.time + updateRate;
    }
  }

  void GraphOrganisms()
  {
    if (!graph)
      return;
    foreach (string key in data.Keys)
    {
      graph.GetComponent<GraphPanel>().AddNode(Time.time, data[key], key);
    }
  }

  Dictionary<string, int> GetData()
  {
    return data;
  }

  void CountOrganisms()
  {
    // Clear the data
    data = new Dictionary<string, int>();

    foreach (Transform child in ecosystem.transform)
    {
      // Don't count it unless it's an organism
      if (!(child.gameObject.GetComponent("Organism")))
        continue;
      // Get the organism's name
      string child_name = child.tag;
      int temp;
      // Increment the counter or add a new counter
      if (data.TryGetValue(child_name, out temp))
        data[child_name] = temp + 1;
      else
        data.Add(child_name, 1);
    }
  }

  string ToString()
  {
    string output = "";

    output += "{";

    bool first_one = true;
    foreach (string key in data.Keys)
    {
      if (!first_one)
        output += ", ";
      output += key + ": " + data[key];
      first_one = false;
    }

    output += "}";

    return output;
  }
}

