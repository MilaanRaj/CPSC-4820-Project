using UnityEngine;
using System.Collections;

public class WaveSpawner : MonoBehaviour
{
    public Transform enemyPrefab;

    public Transform spawnPoint;

    public float timeBetweenWaves = 5f;
    private float countDown = 2f;

    private int waveNumber = 1;

    private int waveIndex = 0;

    private void Update()
    {
        if(countDown <= 0)
        {
            StartCoroutine(SpawnWave());
            countDown = timeBetweenWaves;
        }

        countDown -= Time.deltaTime;
    }

    IEnumerator SpawnWave()
    {
        Debug.Log("Wave Incoming!");

        for (int i = 0; i < waveNumber; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(0.5f);

        }
        waveNumber++;
    }

    void SpawnEnemy()
    {
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}
