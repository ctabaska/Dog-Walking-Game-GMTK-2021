using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInstance
{
    public int Round;

    public Checkpoint [] currentCheckpoints;

    public GameInstance(int round)
    {
       
    }
   
    public void ProgressCheckpoint()
    {
        int index = 0;
        foreach (Checkpoint current in currentCheckpoints)
        {
            if (!current.Complete)
            {
                if (index != 0)
                    currentCheckpoints[index - 1].CheckpointObject.SetActive(false);
                current.CheckpointObject.SetActive(true);
            }
            index++;
        }
    }

    public void Update()
    {

    }

    public void InstantiateGame()
    {
        int NeighborCount = (int) Mathf.Round(Mathf.Sqrt(3 * Round));

        int checkpointCount = (int) Mathf.Round(Mathf.Sqrt(Round));
        Debug.Log($"Round: {Round}, Checkpoint count: {checkpointCount}");

        currentCheckpoints = new Checkpoint[checkpointCount];
        /*for (int i = 0; i < checkpointCount; i++) 
            currentCheckpoints[i] = new Checkpoint(GetRandomCheckpoint());*/
    }/*

    public Vector2 GetRandomCheckpoint()
    {
        return AllCheckpoints[(int)Mathf.Abs(Random.Range(0, AllCheckpoints.Length - 1))];
    }*/

}
