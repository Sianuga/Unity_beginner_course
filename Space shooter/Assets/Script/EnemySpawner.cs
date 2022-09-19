using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] List<WaveConfig> waveConfigs;
    [SerializeField] int startingWave = 0;
    [SerializeField] bool looping = false;




    // Start is called before the first frame update
    IEnumerator Start()
    {
        do
        {
            yield return StartCoroutine(SpawnAllWaves());
        }
        while (looping == true);
        
    }   

   private IEnumerator SpawnAllEnemiesInWave(WaveConfig waveConfig)
    {
        var EnemyCount = waveConfig.GetNumberOfEnemies();
        for(int i=0;i<EnemyCount;i++)
        {
            var newEnemy = 
 Instantiate(waveConfig.GetEnemyPrefab(), waveConfig.GetWaypoints()[0].transform.position, Quaternion.identity);
            newEnemy.GetComponent<EnemyPathing>().SetWaveConfig(waveConfig);
        yield return new WaitForSeconds(waveConfig.GetSpawnTime());
        }
       

    }
    private IEnumerator SpawnAllWaves()
    {
        for(int i=startingWave;i<waveConfigs.Count;i++)
        {
            var currentWave = waveConfigs[i];
            yield return StartCoroutine(SpawnAllEnemiesInWave(currentWave));
        }
    }
}
