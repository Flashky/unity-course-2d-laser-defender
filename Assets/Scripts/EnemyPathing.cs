using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

public class EnemyPathing : MonoBehaviour
{
    // Configurable parameters
    WaveConfig waveConfig;

    // Status
    List<Transform> waypoints;
    int waypointIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        waypoints = waveConfig.GetWaypoints();
        transform.position = waypoints[waypointIndex].position;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    public void SetWaveConfig(WaveConfig waveConfig)
    {
        this.waveConfig = waveConfig;
    }

    private void Move()
    {
        if (waypointIndex <= waypoints.Count - 1)
        {
            MoveToWaypoint();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void MoveToWaypoint()
    {
        var targetPosition = waypoints[waypointIndex].position;
        var movementThisFrame = waveConfig.GetMoveSpeed() * Time.deltaTime;

        transform.position = Vector2.MoveTowards(transform.position, targetPosition, movementThisFrame);
        
        float distance = Vector2.Distance(targetPosition, transform.position);

        if (transform.position == targetPosition)
        {
            waypointIndex++;
        }

    }

}
