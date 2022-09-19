using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement_player : MonoBehaviour
{
    [Header("Player")] 

    [SerializeField] float moveSpeed=10f;
    [SerializeField] float padding = 1f;
    [SerializeField] int health = 200;
    [SerializeField] AudioClip sfx_shoot;
    [SerializeField] float shoot_volume; 
    [SerializeField] AudioClip sfx_death;
    [SerializeField] float death_volume;
    [SerializeField] GameObject particles_death;

    [Header("Projectile")]
    [SerializeField] GameObject laserPrefab;
    [SerializeField] float projectileSpeed= 10f;
    [SerializeField] float projectileFiringPeriod = 0.1f;

    Coroutine firingCouroutine;

    float Xmin;
    float Xmax;
    float Ymin;
    float Ymax;



    // Start is called before the first frame update
    void Start()
    {
        SetUpMoveBoundaries();

    }

 
   

    private void SetUpMoveBoundaries()
    {
        Camera gameCamera = Camera.main;
        Xmin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + padding;
        Xmax = gameCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - padding;
        Ymin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y + padding;
        Ymax = gameCamera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y - padding;


    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Fire();
    }

    private void Fire()
    {
        if (Input.GetButtonDown("Fire1"))
        {
           firingCouroutine = StartCoroutine(FireContinously());
           


        }
        if(Input.GetButtonUp("Fire1"))
        {
            StopCoroutine(firingCouroutine);
        }
    }

  

    IEnumerator FireContinously()
    {
        while (true)
        {
 GameObject laser = Instantiate<GameObject>(laserPrefab, transform.position, Quaternion.identity); //as gameObject;
            laser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, projectileSpeed);
            AudioSource.PlayClipAtPoint(sfx_shoot, Camera.main.transform.position, shoot_volume);
        yield return new WaitForSeconds(projectileFiringPeriod);
        }


    }
    private void Move()
    {
       var deltaX = Input.GetAxis("Horizontal") * Time.deltaTime* moveSpeed;
   var deltaY = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;
        var newXPos = Mathf.Clamp(transform.position.x + deltaX, Xmin, Xmax);
        var newYPos = Mathf.Clamp(transform.position.y + deltaY, Ymin, Ymax);
transform.position = new Vector2(newXPos, newYPos);
    }



    private void OnTriggerEnter2D(Collider2D hit)
    {
        DamageDealer damage = hit.gameObject.GetComponent<DamageDealer>();
        if(!damage) { return; }
        health -= damage.GetDamage();
        FindObjectOfType<GameSession>().DecreaseHealth(damage.GetDamage()); 
        damage.Hit();
        if (health<=0)
        {
            AudioSource.PlayClipAtPoint(sfx_death, Camera.main.transform.position, death_volume);
            Destroy(gameObject);
            Instantiate(particles_death, transform.position, Quaternion.identity);
            FindObjectOfType<Scene_Loader>().LoadEndMenu();
        }
    }
    public int GetHealth()
    {
        return health;
    }
}
