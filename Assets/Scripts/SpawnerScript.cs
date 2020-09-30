using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScript : MonoBehaviour
{
    public GameObject prefab1, prefab2;

    public float spawnRate = 1f;

    float nextSpawn = 0.0f;

    int whatToSpawn;
    // Update is called once per frame
    void Update()
    {
        if(Time.time > nextSpawn)
        {
            whatToSpawn = Random.Range(0, 100);
            Debug.Log(whatToSpawn);

            if(whatToSpawn % 2 == 0)
            {
                Instantiate(prefab1, new Vector2(Random.Range(-10, 10), 7), Quaternion.identity);
            }
            else
            {
                Instantiate(prefab2, new Vector2(Random.Range(-10, 10), 7), Quaternion.identity);
            }
            nextSpawn = Time.time + spawnRate;
        }
    }
}
