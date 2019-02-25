using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{

    public GameObject enemy;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnEnemy", 20,5);
    }

    void SpawnEnemy()
    {
        Vector3 spawnPoint = new Vector3(Random.Range(-2.5f, 2.5f), 0.2f, Random.Range(-2.5f, 2.5f));
        Instantiate(enemy, spawnPoint, new Quaternion());
    }
}
