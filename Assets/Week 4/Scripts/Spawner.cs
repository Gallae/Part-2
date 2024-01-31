using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    float timerRange = Random.Range(1, 5);
    public GameObject prefab1, prefab2, prefab3, prefab4;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timerRange -= (0.5f * Time.deltaTime);
        if (timerRange < 0.1)
        {
            SpawnPlane();
        }
    }
    void SpawnPlane()
    {
        Vector3 spawnPoint = new Vector3(Random.Range(-5, 5), Random.Range(-5, 5), 0);
        Quaternion rotation = Quaternion.Euler(0, 0, 359);
        int whichPlane = Random.Range(1, 4);
        switch (whichPlane)
        {
            case 1: Instantiate(prefab1, spawnPoint, rotation);
                break;
            case 2: Instantiate(prefab2, spawnPoint, rotation);
                break;
            case 3: Instantiate(prefab3, spawnPoint, rotation);
                break;
            case 4: Instantiate(prefab4, spawnPoint, rotation);
                break;
        }
        timerRange = Random.Range(1, 5);
    }
}

