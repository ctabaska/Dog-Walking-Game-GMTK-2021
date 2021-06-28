using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint
{
    private GameObject _CheckpointPrefab;

    public bool Complete;
    public GameObject CheckpointObject;

    public Checkpoint(GameObject prefab, Vector2 location)
    {
        Complete = false;
        _CheckpointPrefab = prefab;

        CheckpointObject = CreateCheckpointObject(location);
    }

    private GameObject CreateCheckpointObject(Vector2 location)
    {
        
        return GameObject.Instantiate(_CheckpointPrefab, location, Quaternion.identity) as GameObject;
    }
}
