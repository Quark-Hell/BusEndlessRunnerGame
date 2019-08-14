using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class CarSpawner : MonoBehaviour
{
    public GameObject[] carPrefab = new GameObject[4];


    int rand;

    // spawn control
    const float MinSpawnDelay = 1;
    const float MaxSpawnDelay = 1;
    Timer spawnTimer;

    // spawn coordinates
        // left road
    Vector3 leftRoad0 = new Vector3(-2.5f, 0, 146);
    Vector3 leftRoad1 = new Vector3(-5.5f, 0, 146);
        // right road
    Vector3 rightRoad0 = new Vector3(2.5f, 0, 146);
    Vector3 rightRoad1 = new Vector3(5.5f, 0, 146);


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
                SpawnCarLeft();
            }
            else if (rand == 1)
            {
                SpawnCarRight();
            }

            // change spawn timer duration and restart
            spawnTimer.Duration = Random.Range(MinSpawnDelay, MaxSpawnDelay);
            spawnTimer.Run();
        }
    }

    void SpawnCarLeft()
    {
        rand = Random.Range(0, 2);
        int randCar = Random.Range(0, 6);
        // generate random location and create new teddy bear
        GameObject car = Instantiate(carPrefab[randCar]) as GameObject;
        if (rand == 0)
        {
            car.gameObject.GetComponent<CarMovement>().leftRoad = true;
            car.transform.rotation = new Quaternion(0, 180, 0, 0);
            car.transform.position = leftRoad0;
        }
        else if (rand == 1)
        {
            car.gameObject.GetComponent<CarMovement>().leftRoad = true;
            car.transform.rotation = new Quaternion(0, 180, 0, 0);
            car.transform.position = leftRoad1;
        }
    }

    void SpawnCarRight()
    {
        rand = Random.Range(0, 2);
        // generate random location and create new teddy bear
        GameObject car = Instantiate(carPrefab[0]) as GameObject;
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
