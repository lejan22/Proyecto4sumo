using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    private float spawnPositionRange = 9f;
    

    
    // Start is called before the first frame update
    void Start()
    {

        InvokeRepeating("SpawnEnemy", 0, 4);
         
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private Vector3 RandomSpawnPos()
    {
        float xRandom = Random.Range(-spawnPositionRange, spawnPositionRange);
        float zRandom = Random.Range(-spawnPositionRange, spawnPositionRange);
        return new Vector3(xRandom, 0, zRandom);
    }
    public void SpawnEnemy()
    {
        Instantiate(enemyPrefab, RandomSpawnPos(), enemyPrefab.transform.rotation);
    }
}
