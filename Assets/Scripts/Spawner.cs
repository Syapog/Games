using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public float SpawnRate = 5f;
    public GameObject enemy;
    public Transform SpawnPoint;
    Transform player;
    float spawnTimer = 0f;

    private void Start()
    {
        player = FindObjectOfType<ZDOROVIE>().GetComponent<Transform>();

    }

    private void Update()
    {
            if (spawnTimer < SpawnRate)
                spawnTimer += Time.deltaTime;
            else
            {
                spawnTimer = 0f;
                Shoot();
            }
        
    }

    private void Shoot()
    {
        GameObject spawnerenemy = Instantiate(enemy, SpawnPoint.position, SpawnPoint.rotation);
        
    }
}
