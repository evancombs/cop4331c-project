using UnityEngine;
using UnityEngine.UI;

public class Ecosystem : MonoBehaviour
{
    public GameObject preySpecies;
    public GameObject predatorSpecies;
    public GameObject floraSpecies;
    public GameObject waterSource;
    public Button play, pause, populate;
    bool displayUI;
    public GameObject UI;


    public int xSize = 200;
    public int zSize = 200;

    public void Pause()
    {
        Time.timeScale = 0;
    }
    public void Play()
    {
        Time.timeScale = 1;
    }
    
    void Start()
    {
        // preySpecies.GetComponent<PredatorDriver>().xSize = xSize;
        pause.onClick.AddListener(Pause);
        play.onClick.AddListener(Play);
        populate.onClick.AddListener(populateEcosystem);
        displayUI = false;
        
        // Testing SAVE LOAD
        // SaveLoadController.Save();
    }

    public void populateEcosystem()
    {
        // Populate the system with some organisms
        int numPrey = 10;
        int numPredator = 10;
        int numFlora = 64;
        int numWater = 5;

        for (int i = 0; i < numPrey; i++)
        {
            GameObject prey = Instantiate(preySpecies, new Vector3((float)Random.Range(0, xSize), 0f, (float)Random.Range(0, zSize)), Quaternion.identity);
            prey.transform.parent = gameObject.transform;
            prey.SetActive(true);
            prey.name = preySpecies.name;
        }
        for (int i = 0; i < numPredator; i++)
        {
            GameObject predator = Instantiate(predatorSpecies, new Vector3((float)Random.Range(0, xSize), 0f, (float)Random.Range(0, zSize)), Quaternion.identity);
            predator.transform.parent = gameObject.transform;
            predator.SetActive(true);
            predator.name = predatorSpecies.name;
        }
        for (int i = 0; i < numFlora; i++)
        {
            GameObject flora = Instantiate(floraSpecies, new Vector3((float)Random.Range(0, xSize), 0f, (float)Random.Range(0, zSize)), Quaternion.identity);
            flora.transform.parent = gameObject.transform;
            flora.SetActive(true);
            flora.name = floraSpecies.name;
            flora.GetComponent<Flora>().waterLevel = Random.Range(15f, 100f);
        }
        for (int i = 0; i < numWater; i++)
        {
            GameObject water = Instantiate(waterSource, new Vector3((float)Random.Range(0, xSize), 0f, (float)Random.Range(0, zSize)), Quaternion.identity);
            water.transform.parent = gameObject.transform;
            water.SetActive(true);
            water.name = waterSource.name;
        }
    }


    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject.FindGameObjectWithTag("MainCamera").GetComponent<MoveCamera>().cameraLocked = !GameObject.FindGameObjectWithTag("MainCamera").GetComponent<MoveCamera>().cameraLocked;
            displayUI = !displayUI;
            
        }

        if (displayUI)
            UI.SetActive(true);
        else
            UI.SetActive(false);

    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(Vector3.zero, new Vector3(xSize, 0, 0));
        Gizmos.DrawLine(new Vector3(xSize, 0, 0), new Vector3(xSize, 0, zSize));
        Gizmos.DrawLine(new Vector3(xSize, 0, zSize), new Vector3(0, 0, zSize));
        Gizmos.DrawLine(new Vector3(0, 0, zSize), Vector3.zero);
    }
}
