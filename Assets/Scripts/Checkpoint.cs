using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint
{
    public bool Complete;
    private GameObject _prefab;
    public GameObject CheckpointObject;
    public GameObject UIObject;

    public Checkpoint(GameObject Prefab, Vector2 location)
    {
        Complete = false;
        _prefab = Prefab;

        CheckpointObject = CreateCheckpointObject(location);
    }

    public void SetActive(bool check)
    {
        CheckpointObject.SetActive(check);
    }

    public bool CheckComplete()
    {
        Complete = CheckpointObject.GetComponent<CheckpointScript>().complete;
        return Complete;
    }

    public void CreateUIObjective(GameObject prefab, Vector2 location, GameObject parent)
    {
        Debug.Log("Hello");
        UIObject = GameObject.Instantiate(prefab, parent.transform) as GameObject;
    }

    public void CompleteUIObjective()
    {
        UIObject.GetComponent<UIObjectiveScript>().CompleteAnimation();
    }

    private GameObject CreateCheckpointObject(Vector2 location)
    {
        
        return GameObject.Instantiate(_prefab, location, Quaternion.identity) as GameObject;
    }
}
