using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetScript : MonoBehaviour
{
    float lastPosition;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Animator>().SetInteger("Pet Index",(int)Mathf.Round(Random.Range(0, 11)));
        lastPosition = gameObject.transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        FlipOrientation(); 
    }

    void FlipOrientation()
    {
        float differ = gameObject.transform.position.x - lastPosition;
        if (differ > 0)
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
        }
        else if (differ < 0)
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
        }

        lastPosition = gameObject.transform.position.x;
    }
}
