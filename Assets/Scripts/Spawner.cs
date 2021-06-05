using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject objectToSpawn;
    public GameObject parent;
    public int numberToSpawn;
    public int limit = 20;
    public float rate;

    float spawnTimer;

    void Start()
    {
        spawnTimer = rate;
    }

    void Update()
    {
        if (parent.transform.childCount < limit)
        {
            spawnTimer -= Time.deltaTime;
            if (spawnTimer <= 0f)
            {
                for (int i = 0; i < numberToSpawn; i++)
                {
                    Instantiate(objectToSpawn, new Vector3( transform.position.x, transform.position.y, transform.position.z),
                                                            Quaternion.identity, parent.transform);
                }
                spawnTimer = rate;
            }
        }
    }
}
