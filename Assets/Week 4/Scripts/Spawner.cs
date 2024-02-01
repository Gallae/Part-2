using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    float timerRange = Random.Range(1, 5);
    public List<Sprite> sprites = new List<Sprite>();
    SpriteRenderer spr;

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
        float whichPlane = Random.Range(0, 3);
        spr = GetComponent<SpriteRenderer>();
        spr.sprite = sprites[(int)whichPlane];
        timerRange = Random.Range(1, 5);
    }
}

