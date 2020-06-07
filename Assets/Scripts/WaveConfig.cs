using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

[CreateAssetMenu(menuName = "Enemy Wave Config")]
public class WaveConfig : ScriptableObject
{
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] GameObject pathPrefab;
    [SerializeField] float timeBetweenSpawns = 0.5f;
    [SerializeField] float spawnRandomFactor = 0.3f;
    [SerializeField] int numberOfEnemies = 5;
    [SerializeField] float moveSpeed = 2f;

    public GameObject GetEnemyPrefab() {
        return enemyPrefab;
    }

    public List<Transform> GetWaypoints() 
    {
        var waveWaypoints = new List<Transform>();

        // Get all the waypoints transforms from the pathPrefab
        foreach(Transform child in pathPrefab.transform) {
            waveWaypoints.Add(child);
        }

        return waveWaypoints;
    }

    public float GetTimeBetweenSpawns() {
        return timeBetweenSpawns;
    }

    public float GetSpawnRandomFactor() {
        return spawnRandomFactor;
    }

    public int GetNumberOfEnemies() {
        return numberOfEnemies;
    }
    public float GetMoveSpeed() {
        return moveSpeed;
    }
}
