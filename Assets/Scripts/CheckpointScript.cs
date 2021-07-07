using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointScript : MonoBehaviour
{
    public bool complete = false;
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            complete = true;
        }
    }
}
