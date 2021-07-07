using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIObjectiveScript : MonoBehaviour
{
    public void CompleteAnimation()
    {
        gameObject.GetComponent<Animator>().SetTrigger("Complete");
    }
}
