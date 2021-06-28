using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScript : MonoBehaviour
{
    public GameInstance Game;

    public int TotalAnimals = 1;
    public int AnimalsKept = 1;

    public int AnimalsRecruited = 0;

    public GameObject animalPrefab;

    public GameObject neighborPrefab;

    public GameObject[] Checkpoints;

    // Start is called before the first frame update
    void Start()
    {
        Game.InstantiateGame();
        //StartGame();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame(){
        // create all animal objects
        

        // create all neighbor objects
        int Neightbors = (int)Mathf.Round(Random.Range(3, 8));

        // create array of checkpoints
        int objectivesAmount = (int)Mathf.Round(Random.Range(1, 4));
        Debug.Log(objectivesAmount);
        Checkpoints = new GameObject[objectivesAmount];
        for (int i = 1; i <= objectivesAmount; i++)
        {
            Checkpoints[i-1] = GameObject.Find("Objective Creator").GetComponent<ObjectiveScript>().CreateObjective();
        }

        //
    }

    public void ProceedCheckpoint() 
    {

    }

    public void RecruitAnimal()
    {
        if (Random.Range(0f,1f) <= 0.7)
        {
            AnimalsRecruited += 1;
        }
    }

    public void LoseAnimal()
    {
        if (Random.Range(0f,1f) <= 0.04)
        {
            TotalAnimals -= 1;
        }
    }
}
