using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] int health=100;
    [SerializeField] GameObject shotPrefab;
    [SerializeField] bool isShooting = false;
    [SerializeField] float shotVelocity = 5f;
 float shotCounter;
    [SerializeField] float minDelayBetweenShots=1f;
    [SerializeField] float maxDelayBetweenShots = 3f;
    [SerializeField]  GameObject explosion_particles;
    [SerializeField] AudioClip audioClip;
    [SerializeField] float volume;
    [SerializeField] int scoreValue=100;




    // Start is called before the first frame update

    void Start()
    {
        shotCounter = Random.Range(minDelayBetweenShots, maxDelayBetweenShots);
    }

    // Update is called once per frame
    void Update()
    {
        if(isShooting)
        CountDownAndShoot();
    }

    private void CountDownAndShoot()
    {
        shotCounter -= Time.deltaTime;
        if(shotCounter<=0f)
        {
            Fire();
            shotCounter = Random.Range(minDelayBetweenShots, maxDelayBetweenShots);
        }
    }

    private void Fire()
    {
        var shot =Instantiate<GameObject>(shotPrefab, transform.position, Quaternion.identity);
        shot.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -shotVelocity);
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        DamageDealer damageDealer = other.gameObject.GetComponent<DamageDealer>();
        if (!damageDealer) { return; }
        ProccessHit(damageDealer);
    }

    private void ProccessHit(DamageDealer damageDealer)
    {
        health -= damageDealer.GetDamage();
        damageDealer.Hit();
        if (health <= 0)
        {
            FindObjectOfType<GameSession>().AddToScore(scoreValue);
            GameObject explosion = Instantiate(explosion_particles, transform.position, Quaternion.identity);
            AudioSource.PlayClipAtPoint(audioClip, Camera.main.transform.position, volume);
            Destroy(gameObject);
        }
           
    }


}
