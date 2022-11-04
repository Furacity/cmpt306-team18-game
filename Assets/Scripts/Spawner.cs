using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public GameObject enemyPrefab;

    [SerializeField] private float spawnRate = 2.0f;
    private float spawnTimer;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        SpawnEnemy();
    }

    private void SpawnEnemy()
    {
        if (Time.time > spawnTimer)
        {
            Instantiate(enemyPrefab, transform.position, transform.rotation);
            spawnTimer = Time.time + spawnRate;
        }
    }
}
