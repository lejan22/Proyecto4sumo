using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    private float spawnPositionRange = 9f;
    public GameObject powerup;
    private int enemiesleft;
    private int enemiesPerWave = 1;
    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemyWave(3);
        InvokeRepeating("SpawnEnemy", 0, 4);
        InvokeRepeating("SpawnPowerup", 0, 10);
    }

    // Update is called once per frame
    void Update()
    {
        enemiesleft = FindObjectsOfType<Enemy>().Length;
        if (enemiesleft <= 0)
        {
            SpawnEnemyWave(enemiesPerWave);
            Instantiate(powerup, RandomSpawnPos(), powerup.transform.rotation);
        }
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
    public void SpawnPowerup()
    {
        Instantiate(powerup, RandomSpawnPos(), powerup.transform.rotation);
    }
    private void SpawnEnemyWave(int totalEnemies)
    {
        for (int i = 0; i< totalEnemies; i++)
        {
            SpawnEnemy();
        }
    }
    
}
