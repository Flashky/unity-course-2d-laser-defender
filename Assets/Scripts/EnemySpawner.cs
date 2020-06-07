using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    // Configurable parameters
    [SerializeField] List<WaveConfig> waveConfigs;
    [SerializeField] int startingWave = 0;
    [SerializeField] bool looping = false;

    // Start is called before the first frame update
    IEnumerator Start()
    {
        do
        {
            yield return StartCoroutine(SpawnAllWaves());
        } while (looping);
    }

    private IEnumerator SpawnAllWaves()
    {
        for(int waveIndex = startingWave; waveIndex < waveConfigs.Count; waveIndex++)
        {
            // Spawn wave
            WaveConfig currentWave = currentWave = waveConfigs[waveIndex];
            yield return StartCoroutine(SpawnAllEnemiesInWave(currentWave));
        }
    }

    private IEnumerator SpawnAllEnemiesInWave(WaveConfig waveConfig)
    {
        for(int enemyCount = 0; enemyCount  < waveConfig.GetNumberOfEnemies(); enemyCount++)
        {
            Debug.Log("spawning enemy  " + enemyCount);
           
            // Spawn an enemy
            SpawnEnemy(waveConfig);

            yield return new WaitForSeconds(waveConfig.GetTimeBetweenSpawns());
        }
    }

    private static void SpawnEnemy(WaveConfig waveConfig)
    { 
        var newEnemy = Instantiate(waveConfig.GetEnemyPrefab(),
                                    waveConfig.GetWaypoints()[0].transform.position,
                                    Quaternion.identity);

        newEnemy.GetComponent<EnemyPathing>().SetWaveConfig(waveConfig);
        

       
    }
}
