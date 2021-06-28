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

    public Transform GetRandomCheckpoint()
    {
        Transform checkpoint = null;
        if (Checkpoints == null )
        {
            Checkpoints = gameObject.GetComponentsInChildren<Transform>();
        } 
        if (Checkpoints != null)
        {
           checkpoint = Checkpoints[(int) Mathf.Round(Random.Range(1, Checkpoints.Length))];
        }
        

        return checkpoint;
    }
}
