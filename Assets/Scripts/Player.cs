using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.Animations;
using Quaternion = UnityEngine.Quaternion;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

public class Player : MonoBehaviour
{
    // Constants
    private const string HORIZONTAL = "Horizontal";
    private const string VERTICAL = "Vertical";
    private const String FIRE = "Fire1";

    // Configurable parameters
    [SerializeField] float moveSpeed = 10f;
    [SerializeField] float padding = 1f;
    [SerializeField] GameObject laserPrefab; // Prefabs can only be GameObjects
    [SerializeField] float projectileSpeed = 10f;
    [SerializeField] float projectileFiringPeriod = 1f;

    // Boundaries
    private float xMin;
    private float xMax;
    private float yMin;
    private float yMax;

    // References
    Coroutine firingCoroutine;

    // Start is called before the first frame update
    void Start()
    {
        SetUpMoveBoundaries();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Fire();
    }

    private void Fire()
    {
        if(Input.GetButtonDown(FIRE))
        {
            firingCoroutine = StartCoroutine(FireContinuously());
        }
        if(Input.GetButtonUp(FIRE))
        {
            StopCoroutine(firingCoroutine);
        }
    }

    private IEnumerator FireContinuously()
    {
        while(true) { 
            GameObject laser = Instantiate(laserPrefab, transform.position, Quaternion.identity); // Quaternion.identity means 'no rotation applied'
            laser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, projectileSpeed);
            yield return new WaitForSeconds(projectileFiringPeriod);
        }

    }

    private void Move()
    {
        var deltaX = Input.GetAxis(HORIZONTAL) * Time.deltaTime * moveSpeed;
        var deltaY = Input.GetAxis(VERTICAL) * Time.deltaTime * moveSpeed;
        
        var newPosX = Mathf.Clamp(transform.position.x + deltaX, xMin, xMax);
        var newPosY = Mathf.Clamp(transform.position.y + deltaY, yMin, yMax);

        transform.position = new Vector2(newPosX, newPosY);
    }

    private void SetUpMoveBoundaries()
    {
        Camera gameCamera = Camera.main;

        Vector3 bottomLeft = new Vector3(0, 0, 0);
        Vector3 topRight = new Vector3(1, 1, 1);

        xMin = gameCamera.ViewportToWorldPoint(bottomLeft).x + padding;
        xMax = gameCamera.ViewportToWorldPoint(topRight).x - padding;
        yMin = gameCamera.ViewportToWorldPoint(bottomLeft).y + padding;
        yMax = gameCamera.ViewportToWorldPoint(topRight).y - padding;
    }
}
