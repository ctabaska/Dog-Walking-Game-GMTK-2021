using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScript : MonoBehaviour
{
    public GameInstance Game;

    public GameObject Player;

    public int TotalAnimals = 1;
    public int AnimalsKept = 1;

    public int AnimalsRecruited = 0;

    public GameObject animalPrefab;
    public GameObject[] pets;

    [SerializeField]private float AnimalSpawnRadius; // The radius that an animal can spawn around the player

    public GameObject neighborPrefab;
    public GameObject[] Neighbors;

    public Vector2[] KeyPositions;
    public GameObject CheckpointPrefab;
    public static Checkpoint[] Checkpoints;
    public int currentCheckpoint;

    public GameObject UIObjectivePrefab;
    public GameObject UIParentObject;
    public Transform UIParentLocation;
    public float UIDistanceApart;

    public int Round;

    // Start is called before the first frame update
    void Start()
    {
        //Game.InstantiateGame();
        StartGame();
    }

    // Update is called once per frame
    void Update()
    {
        if (Checkpoints[currentCheckpoint].CheckComplete())
            ProceedCheckpoint();
    }

    public void StartGame(){
        // move character to a randomly chosen location in keypositions
        GameObject.Find("Player").transform.position = KeyPositions[(int)Mathf.Round(Random.Range(0, KeyPositions.Length - 1))];

        // create all animal objects
        pets = new GameObject[TotalAnimals];
        for (int i = 0; i < pets.Length; i++)
        {
            pets[i] = GameObject.Instantiate(animalPrefab, Player.transform.position + (Vector3)(Random.insideUnitCircle * AnimalSpawnRadius), Quaternion.identity) as GameObject;
        }
        

        // create all neighbor objects
        Neighbors = new GameObject[(int)Mathf.Round(Random.Range(3, 8 + (Round * 2/3)))];
        for (int i = 0; i < Neighbors.Length; i++)
        {
            Neighbors[i] = GameObject.Instantiate(neighborPrefab, KeyPositions[(int)Mathf.Round(Random.Range(0, KeyPositions.Length))], Quaternion.identity) as GameObject;
        }

        // create all checkpoints based on round
        int CheckpointCount = (int)Mathf.Round(Random.Range(2, Mathf.Sqrt(Round / 2) + 4));
        Checkpoints = new Checkpoint[CheckpointCount];
        for (int i = 0; i <Checkpoints.Length; i++)
        {
            Checkpoints[i] = new Checkpoint(CheckpointPrefab, KeyPositions[(int)Mathf.Round(Random.Range(0, KeyPositions.Length))]);
            Checkpoints[i].CreateUIObjective(UIObjectivePrefab, new Vector2(UIParentLocation.position.x + (i - (Checkpoints.Length / 2)) * UIDistanceApart, UIParentLocation.position.y), UIParentObject);
            Checkpoints[i].SetActive(false);
        }
        Checkpoints[0].SetActive(true);
        currentCheckpoint = 0;
    }

    public void ProceedCheckpoint() 
    {
        Checkpoints[currentCheckpoint].SetActive(false);
        Checkpoints[currentCheckpoint].CompleteUIObjective();
        if (Checkpoints.Length - 1 >= currentCheckpoint + 1)
        {
            Checkpoints[currentCheckpoint + 1].SetActive(true);
            currentCheckpoint++;
        }
        else
        {
            FinishObjectives();
        }
        
    }

    public void FinishObjectives()
    {
        Debug.Log("Hello");
    }

    public void RecruitAnimal()
    {
        if (Random.Range(0f, 1f) <= 0.7)
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
