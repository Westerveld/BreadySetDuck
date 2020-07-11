using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject[] potentialObstacles;
    public GameObject[] spawnPoints;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }


    void SpawnObstacle()
    {
        int index = Random.Range(0, potentialObstacles.Length);
        GameObject objectToSpawn = potentialObstacles[index];

        int index2ElectricBoogaloo = Random.Range(0, spawnPoints.Length);
        GameObject spawnPoint = spawnPoints[index2ElectricBoogaloo];
        Instantiate(objectToSpawn, spawnPoint.transform.position, Quaternion.identity);
    }
}
