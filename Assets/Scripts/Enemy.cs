using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using Random = UnityEngine.Random;

public class Enemy : MonoBehaviour
{
    [SerializeField] float health = 100f;

    [SerializeField] GameObject explosionVFX;
    [SerializeField] float explosionTime = 1f;

    [SerializeField] GameObject laserPrefab; // Prefabs can only be GameObjects
    [SerializeField] float projectileSpeed = 10f;

    [SerializeField] float shotCounter;
    [SerializeField] float minTimeBetweenShots = 0.2f;
    [SerializeField] float maxTimeBetweenShots = 3f;
    
    float cooldown = 0f;

    // Start is called before the first frame update
    void Start()
    {
        shotCounter = Random.Range(minTimeBetweenShots, maxTimeBetweenShots);
    }

    // Update is called once per frame
    void Update()
    {
        CountDownAndShoot();
    }

    private void CountDownAndShoot()
    {
        shotCounter -= Time.deltaTime;
        if(shotCounter <= 0)
        {
            Fire();
            shotCounter = Random.Range(minTimeBetweenShots, maxTimeBetweenShots);
        }
    }

    private void Fire()
    {
        // Apply cooldown

        // Create laser and apply velocity
        GameObject laser = Instantiate(laserPrefab, transform.position, Quaternion.identity); // Quaternion.identity means 'no rotation applied'
        laser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -projectileSpeed);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        DamageDealer damageDealer = collision.gameObject.GetComponent<DamageDealer>();

        ProcessHit(collision, damageDealer);
    }

    private void ProcessHit(Collider2D collision, DamageDealer damageDealer)
    {
        health -= damageDealer.GetDamage();

        if (health <= 0)
        {
            Explosion();
            Destroy(gameObject);
            damageDealer.Hit();
        }
    }

    private void Explosion()
    {
        explosionVFX = Instantiate(explosionVFX, transform.position, transform.rotation);
        Destroy(explosionVFX, explosionTime);
    }
}
