using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointScript : MonoBehaviour
{
    public static Transform[] Checkpoints;

    // Start is called before the first frame update
    void Start()
    {
        Checkpoints = gameObject.GetComponentsInChildren<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static Transform GetRandomCheckpoint()
    {
        Transform checkpoint = Checkpoints[(int) Mathf.Round(Random.Range(1, Checkpoints.Length))];

        return checkpoint;
    }
}
