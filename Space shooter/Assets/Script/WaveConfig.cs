using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemy wave config")]

public class WaveConfig : ScriptableObject
{
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] GameObject pathPrefab;
    [SerializeField] float timeBetweenSpawns = 0.6f;
    [SerializeField] float spawnRandomFactor = 0.2f;
    [SerializeField] int numberOfEnemies = 1;
    [SerializeField] float movementSpeed = 3f;
    
    public GameObject GetEnemyPrefab()
    {
        return enemyPrefab;
    }
    public float GetSpawnTime()
    {
        return timeBetweenSpawns;
    }
    public List<Transform> GetWaypoints()
    {
        var waveWaypoints = new List<Transform>();
        foreach(Transform child in pathPrefab.transform)
        {
            waveWaypoints.Add(child);
        }

        return waveWaypoints;
    }
    public float GetSpawnRandomizer()
    {
        return spawnRandomFactor;
    }
    public int GetNumberOfEnemies()
    {
        return numberOfEnemies;
    }
    public float GetMovementSpeed()
    {
        return movementSpeed;
    }









}
