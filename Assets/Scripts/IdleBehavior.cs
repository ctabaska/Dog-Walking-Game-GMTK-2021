using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleBehavior : StateMachineBehaviour
{
    public bool foundDog = false;

    public GameObject targetDog; 

    GameObject[] currentDogs;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       currentDogs = GameObject.FindGameObjectsWithTag("Dog");
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       if (currentDogs == null)
       {
           currentDogs = GameObject.FindGameObjectsWithTag("Dog");
       } else {
           // collider of dogs in the area
           Collider2D[] colliders = Physics2D.OverlapCircleAll(animator.transform.position, animator.gameObject.GetComponent<NeighborScript>().DogRadius, animator.gameObject.GetComponent<NeighborScript>().WhatIsDog);
           
           if (colliders.Length >= 1)
           {
               
            //    targetDog = colliders[0].gameObject;
               targetDog = colliders[(int)Mathf.Round(Random.Range(0, colliders.Length - 1))].gameObject;
           } else {
               targetDog = null;
           }
       }

       if (targetDog != null)
       {
           animator.gameObject.transform.position = Vector2.MoveTowards(animator.gameObject.transform.position, targetDog.transform.position, animator.gameObject.GetComponent<NeighborScript>().moveSpeed * 0.1f);
       }

    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    // override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    // {
       
    // }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
