using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class HouseSpawner : MonoBehaviour
{
    public GameObject[] housePrefab = new GameObject[4];

    int rand;

    // spawn control
    const float MinSpawnDelay = 0.5f;
    const float MaxSpawnDelay = 1;
    Timer spawnTimer;

    // spawn coordinates
    // left road
    [SerializeField]
    Vector3 leftRoad0 = new Vector3(-22f, 0, 246);
    [SerializeField]
    Vector3 leftRoad1 = new Vector3(-33f, 0, 246);
    // right road
    [SerializeField]
    Vector3 rightRoad0 = new Vector3(22f, 0, 246);
    [SerializeField]
    Vector3 rightRoad1 = new Vector3(33f, 0, 246);


    void Start()
    {
        // create and start timer
        spawnTimer = gameObject.AddComponent<Timer>();
        spawnTimer.Duration = Random.Range(MinSpawnDelay, MaxSpawnDelay);
        spawnTimer.Run();

    }

    // Update is called once per frame
    void Update()
    {
        rand = Random.Range(0, 2);
        // check for time to spawn a new teddy bear
        if (spawnTimer.Finished)
        {
            if (rand == 0)
            {
                SpawnHouseLeft();
            }
            else if (rand == 1)
            {
                SpawnHouseRight();
            }

            // change spawn timer duration and restart
            spawnTimer.Duration = Random.Range(MinSpawnDelay, MaxSpawnDelay);
            spawnTimer.Run();
        }
    }

    void SpawnHouseLeft()
    {
        rand = Random.Range(0, 2);
        int randHouse = Random.Range(0, housePrefab.Length);
        // generate random location and create new house
        GameObject house = Instantiate(housePrefab[randHouse]) as GameObject;
        if (rand == 0)
        {
            house.gameObject.GetComponent<HouseMovement>().leftRoad = true;
            house.transform.position = leftRoad0;
        }
        else if (rand == 1)
        {
            house.gameObject.GetComponent<HouseMovement>().leftRoad = true;
            house.transform.position = leftRoad1;
        }
    }

    void SpawnHouseRight()
    {
        rand = Random.Range(0, 2);
        int randHouse = Random.Range(0, housePrefab.Length);
        // generate random location and create new house
        GameObject car = Instantiate(housePrefab[randHouse]) as GameObject;
        if (rand == 0)
        {
            car.transform.position = rightRoad0;
        }
        else if (rand == 1)
        {
            car.transform.position = rightRoad1;
        }
    }
}
