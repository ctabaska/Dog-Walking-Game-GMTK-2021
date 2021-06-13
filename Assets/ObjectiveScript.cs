using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveScript : MonoBehaviour
{
    public static Transform currentObjective;

    public GameObject ObjectivePrefab;

    public GameObject currentObjectiveObject;

    // Start is called before the first frame update
    void Start()
    {
        CreateObjective();
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    public static void CreateObjective()
    {
        currentObjective = CheckpointScript.GetRandomCheckpoint();

        currentObjectiveObject = Instantiate(ObjectivePrefab, currentObjective.position, Quaternion.identity);
    }
}
