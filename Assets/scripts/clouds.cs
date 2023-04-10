using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clouds : MonoBehaviour
{
    public GameObject cloud;
    public float floCloudSpawn;
    float floSpawnTime;
    void Start()
    {
        floSpawnTime = floCloudSpawn;
    }

    void Update()
    {
        floCloudSpawn -= Time.deltaTime;
        if (floCloudSpawn < 0)
        {
            Vector3 pos = new Vector3(transform.position.x, (Random.Range(-1, 2) + transform.position.y), 0);
            GameObject clo = Instantiate(cloud, pos, transform.rotation);
            Destroy(clo, 40);
            floCloudSpawn = floSpawnTime;
        }
    }
}
