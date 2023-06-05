using UnityEngine;
using System.Collections;

public class wavespawner : MonoBehaviour
{
    public Transform enemyPrefab;
    public Transform spawnPoint;
    public float timebetweenWaves = 5f;
    private float countdown = 2f;
    private int waveIndex = 0;
    void Update(){
        if(countdown <= 0f){
            StartCoroutine(SpawnWave());
            countdown = timebetweenWaves;
        }
        countdown -= Time.deltaTime;
    }
    IEnumerator SpawnWave(){
        waveIndex++;
        for(int i = 0; i < waveIndex; i++){
            SpawnEnemy();
            yield return new WaitForSeconds(0.5f);
        }
    }
    void SpawnEnemy(){
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}
