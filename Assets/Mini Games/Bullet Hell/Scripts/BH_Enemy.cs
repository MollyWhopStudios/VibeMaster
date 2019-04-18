using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BH_Enemy : MonoBehaviour
{
    [SerializeField] float health = 100;

    [SerializeField] float shotCounter;
    [SerializeField] float minTimeBetweenShots = 0.2f;
    [SerializeField] float maxTimeBetweenShots = 3f;
    [SerializeField] GameObject laserPrefab;
    [SerializeField] float projectileSpeed = 10f;

    [SerializeField] GameObject deathVFX;
    [SerializeField] float durationOfExplosion = 5f;

    [SerializeField] AudioClip deathSound;
    [SerializeField] [Range(0,1)] float deathSoundVolume = 0.7f;

    [SerializeField] AudioClip shootSound;
    [SerializeField] [Range(0, 1)] float shootSoundVolume = 0.4f;


    // Start is called before the first frame update
    void Start()
    {
        // random shot interval
        shotCounter = UnityEngine.Random.Range(minTimeBetweenShots, maxTimeBetweenShots);
    }

    // Update is called once per frame
    void Update()
    {
        //CountDownAndShoot();
    }
    
    /* No Projectiles
    private void CountDownAndShoot()
    {
        shotCounter -= Time.deltaTime;
        if (shotCounter <= 0f)
        {
            Fire();
        }
    }

    private void Fire()
    {
        // spawn laser
        GameObject laser = Instantiate(laserPrefab,
                                       transform.position,
                                       Quaternion.identity
                                       ) as GameObject;
        // "shoot"
        laser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -projectileSpeed);
        AudioSource.PlayClipAtPoint(shootSound, Camera.main.transform.position, shootSoundVolume);
        // reset counter
        shotCounter = UnityEngine.Random.Range(minTimeBetweenShots, maxTimeBetweenShots);
    }
    */
    private void OnTriggerEnter2D(Collider2D other)
    {
        BH_DamageDealer damageDealer = other.gameObject.GetComponent<BH_DamageDealer>();
        if (!damageDealer) { return; } // protect against null
        ProcessHit(damageDealer);
    }

    private void ProcessHit(BH_DamageDealer damageDealer)
    {
        health -= damageDealer.GetDamage();
        damageDealer.Hit();
        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
        GameObject explosion = Instantiate(deathVFX, transform.position, transform.rotation);
        Destroy(explosion, durationOfExplosion);
        AudioSource.PlayClipAtPoint(deathSound, Camera.main.transform.position, deathSoundVolume);
    }
}
