using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint
{
    public bool Complete;
    public GameObject CheckpointObject;

    public Checkpoint(Vector2 location)
    {
        Complete = false;

        CheckpointObject = CreateCheckpointObject(location);
    }

    public void SetActive(bool check)
    {
        CheckpointObject.SetActive(check);
    }

    private GameObject CreateCheckpointObject(Vector2 location)
    {
        
        return GameObject.Instantiate(GameScript.CheckpointPrefab, location, Quaternion.identity) as GameObject;
    }
}
