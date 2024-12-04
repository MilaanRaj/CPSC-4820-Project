using UnityEngine;
using System.Collections;

public class WaveSpawner : MonoBehaviour
{
    public Transform enemyPrefab;

    public Transform bossPrefab;

    public Transform spawnPoint;

    public AudioSource audioSource;

    public float timeBetweenWaves = 5f;
    private float countDown = 2f;

    public int waveNumber = 1;

    private int waveIndex = 0;

    public int maxWaves = 20;

    public Canvas winCanvas;
    public Canvas playCanvas;


    private void Update()
    {
        if (countDown <= 0)
        {
            StartCoroutine(SpawnWave());
            countDown = timeBetweenWaves;
        }

        countDown -= Time.deltaTime;
    }

    IEnumerator SpawnWave()
    {
        Debug.Log("Wave Incoming!");
        if (waveNumber == 10){
            //handle win or loss logic here for now just assume win
            playCanvas.gameObject.SetActive(false);
            winCanvas.gameObject.SetActive(true);
            audioSource.Stop();

        }
        //if ((waveNumber - 1) > maxWaves){
            //set win canvas active here if we want no timer
       //     yield return null;
        //}
        else if (waveNumber == 9){
            SpawnBoss();
        }
        else{
            for (int i = 0; i < waveNumber; i++)
            {
                SpawnEnemy();
                yield return new WaitForSeconds(0.5f);

            }
        }
        waveNumber++;
    }

    void SpawnEnemy()
    {
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }

    void SpawnBoss(){
        Instantiate(bossPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}
