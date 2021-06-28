using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveScript : MonoBehaviour
{
    public Transform currentObjective;

    [SerializeField]public GameObject ObjectivePrefab;

    public GameObject currentObjectiveObject;

    public GameObject checkpoints;

    void Awake()
    {
        CreateObjective();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject CreateObjective()
    {
        Transform thisCheckpoint = GameObject.Find("Checkpoints").GetComponent<CheckpointScript>().GetRandomCheckpoint();

        return Instantiate(ObjectivePrefab, thisCheckpoint.position, Quaternion.identity);
      
    }
}
