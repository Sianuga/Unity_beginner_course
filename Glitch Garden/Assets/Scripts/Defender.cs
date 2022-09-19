using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defender : MonoBehaviour
{
    [SerializeField] GameObject projectile;
    [SerializeField] GameObject projectileSpawnPoint;
    [SerializeField] float health;
    [SerializeField] int starCost;
    [SerializeField] bool isShooting=true;
    [SerializeField] GameObject deathVFX;
    Attackerspawner[] spawners;
    Attackerspawner myLaneSpawner;
    Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
        SetLaneSpawner();
        
    }
    private void TriggerVFX()
    {
        if (!deathVFX) { return; }
        Instantiate(deathVFX, transform.position, Quaternion.identity);
    }
    private void Update()
    {
        if(isShooting)
        {
  if(IsAttackerInLane())
        {
            animator.SetBool("IsAttacking", true);
        }
        else
        {
            animator.SetBool("IsAttacking", false);
        }
        }
      
    }
    public void Shoot()
    {
        Instantiate(projectile, projectileSpawnPoint.transform.position, Quaternion.identity);
    }
    private void SetLaneSpawner()
    {
        spawners = FindObjectsOfType<Attackerspawner>();

        foreach (Attackerspawner spawner in spawners)
        {
            bool IsCloseEnough = (Mathf.Abs(spawner.transform.position.y - transform.position.y) <= Mathf.Epsilon);
            if (IsCloseEnough)
            {
                myLaneSpawner = spawner;
            }
        }
    }
    private bool IsAttackerInLane()
    {
        if (myLaneSpawner.transform.childCount <= 0)
        {
            return false;
        }
        else
            return true;
    }
 public int GetStarCost()
    {
        return starCost;
    }

    public void AddStars(int amount)
    {
        FindObjectOfType<StarDisplay>().AddStars(amount);
    }
    public void DealDamage(float damage)
    {
        health -=damage;
        if (health <= 0)
        {
            TriggerVFX();
            Destroy(gameObject);
        }
    }
}
