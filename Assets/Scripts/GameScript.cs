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

    [SerializeField]private float AnimalSpawnRadius; // The radius that an animal can spawn around the player

    public GameObject neighborPrefab;

    public Vector2[] KeyPositions;
    public static GameObject CheckpointPrefab;

    //public GameObject[] Checkpoints;

    // Start is called before the first frame update
    void Start()
    {
        //Game.InstantiateGame();
        StartGame();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame(){
        // move character to a randomly chosen location in keypositions
        GameObject.Find("Player").transform.position = KeyPositions[(int)Mathf.Round(Random.Range(0, KeyPositions.Length - 1))];

        // create all animal objects

        // move all animal objects to a random point in a circle
        

        // create all neighbor objects
        int Neightbors = (int)Mathf.Round(Random.Range(3, 8));

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
